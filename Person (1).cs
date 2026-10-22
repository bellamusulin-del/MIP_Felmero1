using System;
using PersonnelVault.Services;

namespace PersonnelVault.Models
{
    // Az alap "Person" osztály: minden szerepkör (Employee, Manager, Director) ebből öröklődik.
    // Absztrakt, mert önmagában sima "Person"-t nem akarunk létrehozni - valaki mindig
    // valamilyen KONKRÉT szerepkörként létezik a rendszerben.
    //
    // A belépési adatok (username, kódolt jelszó, mentés ideje) is itt élnek -
    // nincs külön "PersonId"-vel összekötött másik osztály, mert ez a projekt
    // méretében ez csak felesleges közvetett hivatkozás lenne.
    public abstract class Person
    {
        public int Id { get; }
        public string Name { get; set; }

        public string Username { get; private set; }
        public string EncodedPassword { get; private set; }
        public DateTime PasswordSavedAt { get; private set; }

        // A Cézár-kód eltolása - egy valós rendszerben ez felhasználónként is
        // változhatna, itt egyszerűség kedvéért közös konstans.
        private const int CipherShift = 5;

        // Egyszerű auto-increment Id, hogy ne kelljen kézzel megadni és ne ütközzenek.
        private static int _nextId = 1;

        protected Person(string name)
        {
            Id = _nextId++;
            Name = name;
        }

        // Beállítja/lecseréli a bejelentkezési adatokat. A jelszót SOHA nem tároljuk
        // eredeti formában - mentés előtt mindig Cézár-kódoljuk.
        public void SetCredentials(string username, string plainPassword)
        {
            Username = username;
            EncodedPassword = CaesarCipher.Encode(plainPassword, CipherShift);
            PasswordSavedAt = DateTime.Now;
        }

        // A tárolt (kódolt) jelszót visszafejtjük, és azt hasonlítjuk a beírt jelszóhoz.
        public bool PasswordMatches(string attemptedPassword)
        {
            if (EncodedPassword == null) return false; // nincs beállítva jelszó

            string decoded = CaesarCipher.Decode(EncodedPassword, CipherShift);
            return decoded == attemptedPassword;
        }

        // Minden leszármazott osztály máshogy "mutatkozik be" -
        // ez klasszikus polimorfizmus: ugyanaz a metódusnév, más-más viselkedés osztályonként.
        public abstract string DescribeRole();

        public override string ToString()
        {
            return $"[{Id}] {Name} - {DescribeRole()}";
        }
    }
}

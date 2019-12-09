using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet
{
    /// <summary>
    /// A Singleton, sealed from inheritance by other classes
    /// </summary>
    public sealed class PrimaryPlayer
    {
        private static readonly PrimaryPlayer _instance;
        public static PrimaryPlayer Instance
        {
            get => _instance;
        }

        public string Name { get; set; }
        public string Level { get; set; }
        public int Armour { get; set; }
        public int Health { get; set; }
        public IWeapon Weapon { get; set; }
        /// <summary>
        /// Default Constructor called in Static Constructor
        /// </summary>
        private PrimaryPlayer() { }

        /// <summary>
        /// Static Constructor, this runs only once and before any first use of <see cref="PrimaryPlayer"/>
        /// </summary>
        static PrimaryPlayer()
        {
            // Utilise Lazy Loading to initialize our instance where the programmer only needs to GET the instance
            _instance = new PrimaryPlayer()
            {
                Name = "Player 1",
                Level = "1",
                Armour = 25,
                Health = 100,
            };
            //TODO: Use Dependency Injection to instantiate instance
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{

    class Character
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string BodyType { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Clothes { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();
        public List<string> GoodDeeds { get; set; } = new List<string>();
        public List<string> EvilDeeds { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Ім'я: {Name}, Зріст: {Height}, Статура: {BodyType}, Волосся: {HairColor}, Очі: {EyeColor}, " +
                   $"Одяг: {Clothes}, Інвентар: {string.Join(", ", Inventory)}, " +
                   $"Добрі вчинки: {string.Join(", ", GoodDeeds)}, Злі вчинки: {string.Join(", ", EvilDeeds)}";
        }
    }

    interface ICharacterBuilder
    {
        ICharacterBuilder SetName(string name);
        ICharacterBuilder SetHeight(string height);
        ICharacterBuilder SetBodyType(string bodyType);
        ICharacterBuilder SetHairColor(string hairColor);
        ICharacterBuilder SetEyeColor(string eyeColor);
        ICharacterBuilder SetClothes(string clothes);
        ICharacterBuilder AddToInventory(string item);
        ICharacterBuilder AddEvilDeed(string deed); 
        Character Build();
    }
    class HeroBuilder : ICharacterBuilder
    {
        private Character _character = new Character();

        public ICharacterBuilder SetName(string name)
        {
            _character.Name = name;
            return this;
        }
        public ICharacterBuilder AddEvilDeed(string deed)
        {
            return this;
        }

        public ICharacterBuilder SetHeight(string height)
        {
            _character.Height = height;
            return this;
        }

        public ICharacterBuilder SetBodyType(string bodyType)
        {
            _character.BodyType = bodyType;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            _character.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            _character.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder SetClothes(string clothes)
        {
            _character.Clothes = clothes;
            return this;
        }

        public ICharacterBuilder AddToInventory(string item)
        {
            _character.Inventory.Add(item);
            return this;
        }

        public Character Build()
        {
            return _character;
        }
    }

    class EnemyBuilder : ICharacterBuilder
    {
        private Character _character = new Character();

        public ICharacterBuilder SetName(string name)
        {
            _character.Name = name;
            return this;
        }

        public ICharacterBuilder SetHeight(string height)
        {
            _character.Height = height;
            return this;
        }

        public ICharacterBuilder SetBodyType(string bodyType)
        {
            _character.BodyType = bodyType;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            _character.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            _character.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder SetClothes(string clothes)
        {
            _character.Clothes = clothes;
            return this;
        }

        public ICharacterBuilder AddToInventory(string item)
        {
            _character.Inventory.Add(item);
            return this;
        }

        public ICharacterBuilder AddEvilDeed(string deed)
        {
            _character.EvilDeeds.Add(deed);
            return this;
        }

        public Character Build()
        {
            return _character;
        }
    }

    class CharacterDirector
    {
        private ICharacterBuilder _builder;

        public CharacterDirector(ICharacterBuilder builder)
        {
            _builder = builder;
        }

        public void SetBuilder(ICharacterBuilder builder)
        {
            _builder = builder;
        }

 
    public Character CreateHero()
        {
            return _builder
                .SetName("Артас")
                .SetHeight("190 см")
                .SetBodyType("Мускулистий")
                .SetHairColor("Блондин")
                .SetEyeColor("Блакитні")
                .SetClothes("Лицарські обладунки")
                .AddToInventory("Меч")
                .AddToInventory("Щит")
                .Build();
        }

        public Character CreateEnemy()
        {
            return _builder
                .SetName("Король Лір")
                .SetHeight("210 см")
                .SetBodyType("Нежить")
                .SetHairColor("Білий")
                .SetEyeColor("Світиться блакитним")
                .SetClothes("Темний плащ")
                .AddToInventory("Фростморн")
                .AddEvilDeed("Знищив село")
                .AddEvilDeed("Створив армію нежиті")
                .Build();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            HeroBuilder heroBuilder = new HeroBuilder();
            EnemyBuilder enemyBuilder = new EnemyBuilder();

            CharacterDirector director = new CharacterDirector(heroBuilder);

            Character hero = director.CreateHero();
            Console.WriteLine("Герой створений:");
            Console.WriteLine(hero);

            director.SetBuilder(enemyBuilder);
            Character enemy = director.CreateEnemy();
            Console.WriteLine("\nВорог створений:");
            Console.WriteLine(enemy);
        }
    }
}



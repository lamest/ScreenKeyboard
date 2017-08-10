using System.Linq;

namespace ScreenKeyboard.Alphabets
{
    public struct Alphabet
    {
        public Key[] Keys { get; }

        public Alphabet(Key[] keys)
        {
            Keys = keys;
        }

        public Key this[string str]
        {
            get { return Keys.First(key => key.View == str); }
        }

        public bool ContainKey(string keyName)
        {
            foreach (var keys in Keys)
                if (keys.View == keyName)
                    return true;
            return false;
        }

        public static Alphabet Russian = new Alphabet(
            new[]
            {
                new Key("а", "А"),
                new Key("б", "Б"),
                new Key("в", "В"),
                new Key("г", "Г"),
                new Key("д", "Д"),
                new Key("е", "Е"),
                new Key("ё", "Ё"),
                new Key("ж", "Ж"),
                new Key("з", "З"),
                new Key("и", "И"),
                new Key("й", "Й"),
                new Key("к", "К"),
                new Key("л", "Л"),
                new Key("м", "М"),
                new Key("н", "Н"),
                new Key("о", "О"),
                new Key("п", "П"),
                new Key("р", "Р"),
                new Key("с", "С"),
                new Key("т", "Т"),
                new Key("у", "У"),
                new Key("ф", "Ф"),
                new Key("х", "Х"),
                new Key("ц", "Ц"),
                new Key("ч", "Ч"),
                new Key("ш", "Ш"),
                new Key("щ", "Щ"),
                new Key("ъ", "Ъ"),
                new Key("ы", "Ы"),
                new Key("ь", "Ь"),
                new Key("э", "Э"),
                new Key("ю", "Ю"),
                new Key("я", "Я")
            }
        );

        public static Alphabet English = new Alphabet(
            new[]
            {
                new Key("a", "A"),
                new Key("b", "B"),
                new Key("c", "C"),
                new Key("d", "D"),
                new Key("e", "E"),
                new Key("f", "F"),
                new Key("g", "G"),
                new Key("h", "H"),
                new Key("i", "I"),
                new Key("j", "J"),
                new Key("k", "K"),
                new Key("l", "L"),
                new Key("m", "M"),
                new Key("n", "N"),
                new Key("o", "O"),
                new Key("p", "P"),
                new Key("q", "Q"),
                new Key("r", "R"),
                new Key("s", "S"),
                new Key("t", "T"),
                new Key("u", "U"),
                new Key("v", "V"),
                new Key("w", "W"),
                new Key("x", "X"),
                new Key("y", "Y"),
                new Key("z", "Z")
            }
        );

        public static Alphabet Numbers = new Alphabet(
            new[]
            {
                new Key("1"),
                new Key("2"),
                new Key("3"),
                new Key("4"),
                new Key("5"),
                new Key("6"),
                new Key("7"),
                new Key("8"),
                new Key("9"),
                new Key("0")
            }
        );

        public static Alphabet Symbols = new Alphabet(
            new[]
            {
                new Key("!"),
                new Key("?"),
                new Key("#"),
                new Key("@"),
                new Key("%"),
                new Key("^"),
                new Key("&"),
                new Key("*"),
                new Key(")"),
                new Key("("),
                new Key(":"),
                new Key(";"),
                new Key("+"),
                new Key("-"),
                new Key("~"),
                new Key("'"),
                new Key("\""),
                new Key("\\"),
                new Key("/"),
                new Key("$"),
                new Key("_"),
                new Key("|"),
                new Key("<"),
                new Key(">"),
                new Key("№"),
                new Key("="),
                new Key("["),
                new Key("]"),
                new Key("`"),
                new Key("{"),
                new Key("}")

                //new List<string>() {"!", "?", "#", "@", "%", "^", "&", "*", ")", "(", "{"},
                //new List<string>() {"$", "_", "|", "<", ">", "№", "=", "[", "]", "`", "}"},
                //new List<string>() {":", ";", "+", "-", "~", "'", "\"", "/", "\\"}
            }
        );
    }
}
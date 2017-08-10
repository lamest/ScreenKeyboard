using System.Collections.Generic;
using System.Linq;
using ScreenKeyboard.Alphabets;

namespace ScreenKeyboard
{
    public class Layout
    {
        public static Layout RussianDefault = new Layout("Ru", new List<List<string>>
        {
            new List<string> {"й", "ц", "у", "к", "е", "н", "г", "ш", "щ", "з", "х"},
            new List<string> {"ф", "ы", "в", "а", "п", "р", "о", "л", "д", "ж", "э"},
            new List<string> {"я", "ч", "с", "м", "и", "т", "ь", "б", "ю"}
        }, Alphabet.Russian);

        public static Layout EnglishDefault = new Layout("En", new List<List<string>>
        {
            new List<string> {"q", "w", "e", "r", "t", "y", "u", "i", "o", "p"},
            new List<string> {"a", "s", "d", "f", "g", "h", "j", "k", "l"},
            new List<string> {"z", "x", "c", "v", "b", "n", "m"}
        }, Alphabet.English);

        public static Layout SymbolsDefault = new Layout("#+=", new List<List<string>>
        {
            new List<string> {"!", "?", "#", "@", "%", "^", "&", "*", ")", "(", "{"},
            new List<string> {"$", "_", "|", "<", ">", "№", "=", "[", "]", "`", "}"},
            new List<string> {":", ";", "+", "-", "~", "'", "\"", "/", "\\"}
        }, Alphabet.Symbols);

        public static Layout NumbersDefault = new Layout("123", new List<List<string>>
        {
            new List<string> {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}
        }, Alphabet.Numbers);

        public Layout(string name, List<List<string>> rows, Alphabet keys)
        {
            Name = name;
            Keys = keys;
            Rows = GenerateRows(rows);
        }

        public Layout(string name, Alphabet keys, int rowsCount)
        {
            Name = name;
            Keys = keys;
            Keys = keys;
        }

        public string Name { get; }

        public List<List<Key>> Rows { get; private set; }

        public Alphabet Keys { get; }

        private List<List<Key>> GenerateRows(List<List<string>> rows)
        {
            var retList = new List<List<Key>>(rows.Count);
            foreach (var row in rows)
            {
                var retRow = new List<Key>(row.Count);
                foreach (var str in row)
                    retRow.Add(Keys[str]);
                retList.Add(retRow);
            }
            return retList;
        }

        private void GenerateLayout(int rowsCount)
        {
            Rows = new List<List<Key>>();
            if (rowsCount > 1)
            {
                int i;
                var keysPerRow = Keys.Keys.Count() / rowsCount;

                for (i = 0; i < rowsCount; i++)
                {
                    var keyList = new List<Key>();
                    var lastIndexPos = i * keysPerRow + keysPerRow - 1;
                    var range = lastIndexPos < Keys.Keys.Count() ? lastIndexPos : Keys.Keys.Count();
                    foreach (var key in Keys.Keys.IndexRange(i * keysPerRow, range))
                        keyList.Add(key);
                    Rows.Add(keyList);
                    if (lastIndexPos > Keys.Keys.Count())
                        break;
                }
            }
            else
            {
                var onlyrow = new List<Key>();
                foreach (var key in Keys.Keys)
                    onlyrow.Add(key);
                Rows.Add(onlyrow);
            }
        }
    }

    /*         public static Alphabet Numbers = new Alphabet(
            new Key[]
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
            new Key[]
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
                new Key("`"),
                new Key("\""),
                new Key("/"),

            }
            );*/
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cs_r_editor
{
    public class AsciiCow
    {
        private static string Cow1 = @"
            /)  (\
       .-._((,~~.))_.-,
        `-.   @@   ,-'
          / ,o--o. \
         ( ( .__. ) )
          ) `----' (
         /          \ I am working ...
        /            \`.
       /              \
";
        private static string Cow2 = @"
            /)   (\
       .-._((,~''~.))_.-,
        `-.   e e   ,-'
          / ,o---o. \
         ( ( .___. ) )
          ) `-----' ( Plz wait ...
         /`-.__ __.-'\`..
              ,8.
             /___\
             `-&-'
";
        private static string Cow3 = @"
           _((,~~.))_.-,
         `-.   @@   ,-'
           / ,n--n. \
   (`'\   ( ( .__. ) )  /`')
    `.''._ ) `----' (_,'`.'
      '._             _,'
         /            \  I'm working ..
        (              )
        (`-.__    __.-')
         \   /`--'\   /
          ) /      \ (
         /._\      /_,\
";
        private static string Cow4 = @"
              /)  (\
         .~._((,"".))_.~,
          `~.   uu   ,~'
            / ,n~~n. \
           { { .__. } }
            ) `~~~~' (
           /`-._  _.-'\ Plz wait ...
          /            \
        ,-X            X-.
       /   \          /   \
      (     )| |  | |(     )
       \   / | |  | | \   /
        \_(.-( )--( )-.)_/
        /_,\ ) /  \ ( /._\
            /_,\  /._\

";
        public static string Get(int index)
        {
            index = index % 4;
            switch (index)
            {
                case 0: return Cow1;
                case 1: return Cow2;
                case 2: return Cow3;
                case 3: return Cow4;
            }
            return Cow2;
        }
    }
}

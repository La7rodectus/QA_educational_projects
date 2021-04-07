using System;
using Xunit;
using IIG.PasswordHashingUtils;


namespace PasswordHashingUtilsTests
{
    [Collection("passwordHasher init params tests")]
    public class PasswordHasherInitMethodTests
    {
        [Theory]
        [InlineData("93", 93)]
        [InlineData("aaaaa", 93)]
        [InlineData("1", 93)]
        [InlineData("!@#$%^&.,`*()_+>-=<?:;~/[]{}", 93)]
        [InlineData("Любі друзі, я вас вітаю і використовую символ Ї", 93)]
        [InlineData("ФІВЦЙУЫЇЁЮ", 93)]
        [InlineData("ASFDGREHWQWEMCNV", 93)]
        [InlineData("", 93)]
        public void initPatamSaltTest(string salt, UInt32 adlerMod)
        {
            try
            {
                PasswordHasher.Init(salt, adlerMod);
                Assert.True(true);
            }
            catch (Exception exption)
            {
                Console.WriteLine(exption);
                Assert.True(false);
            }
           
        }

        [Theory]
        [InlineData(93)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(100)]
        [InlineData(101)]
        [InlineData(1000)]
        [InlineData(12.23)]
        [InlineData(UInt32.MaxValue)]
        public void initPatamAdlerModTest(UInt32 adlerMod)
        {
            try
            {
                PasswordHasher.Init("someSalt", adlerMod);
                Assert.True(true);
            }
            catch (Exception exption)
            {
                Console.WriteLine(exption);
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData('`')]
        [InlineData('"')]
        [InlineData(' ')]
        [InlineData('؂')]
        [InlineData('⏰')]
        [InlineData('☔')]
        [InlineData('⛔')]
        [InlineData('⛰')]
        [InlineData('⿈')]
        [InlineData('㉇')]
        [InlineData('㘗')]
        [InlineData('ꖴ')]
        [InlineData('겅')]
        [InlineData('쓉')]
        [InlineData('♥')]
        [InlineData('|')]
        public void SpecialCharSaltParamInitTest(char salt)
        {
            try
            {
                PasswordHasher.Init(salt.ToString(), 1);
                Assert.True(true);
            }
            catch (Exception exption)
            {
                Console.WriteLine(exption);
                Assert.True(false);
            }
        }

        [Theory]
        [InlineData('\t')]
        [InlineData('\n')]
        [InlineData('\a')]
        [InlineData('\b')]
        [InlineData('\r')]
        [InlineData('\f')]
        [InlineData('\v')]
        [InlineData('\\')]
        [InlineData('\'')]
        [InlineData('\"')]
        public void ComandCombinationsSaltParamInitTest(char salt)
        {
            try
            {
                PasswordHasher.Init(salt.ToString(), 1);
                Assert.True(true);
            }
            catch (Exception exption)
            {
                Console.WriteLine(exption);
                Assert.True(false);
            }
        }

    }

    [Collection("passwordHasher GetHash method params tests")]

    public class PasswordHasherGetHashMethodTests
    {
        [Theory]
        [InlineData("93")]
        [InlineData("aaaaa")]
        [InlineData("1")]
        [InlineData("!@#$%^&.,`*()_+>-=<?:;~/[]{}")]
        [InlineData("Любі друзі, я вас вітаю і використовую символ Ї")]
        [InlineData("ФІВЦЙУЫЇЁЮ")]
        [InlineData("ASFDGREHWQWEMCNV")]
        [InlineData("")]
        public void GetHashRegularStringsTest(string str)
        {
            try
            {
                PasswordHasher.Init("salt", 1);
                string firstHash = PasswordHasher.GetHash(str);
                string secondHash = PasswordHasher.GetHash(str);
                Assert.Equal(firstHash, secondHash);
            }
            catch (Exception exption)
            {
                Console.WriteLine(exption);
                Assert.True(false);
            }

        }

        [Theory]
        [InlineData(" 93 ")]
        [InlineData(" aaaaa")]
        [InlineData(" ")]
        [InlineData(" DsQfFS ііі ЇЇЇ їїї \n ")]
        [InlineData("1 d dsa sd G GDF S SDF SDF  sf1df%$sdЇ               ")]
        [InlineData("                          ")]
        [InlineData("[{*()< d as1112356>d>?}]")]
        [InlineData("")]
        public void GetHashIrregularStringsTest(string str)
        {
            try
            {
                PasswordHasher.Init("salt", 1);
                string firstHash = PasswordHasher.GetHash(str);
                string secondHash = PasswordHasher.GetHash(str);
                Assert.Equal(firstHash, secondHash);
            }
            catch (Exception exption)
            {
                Console.WriteLine(exption);
                Assert.True(false);
            }

        }

        [Theory]
        [InlineData('\t')]
        [InlineData('\n')]
        [InlineData('\a')]
        [InlineData('\b')]
        [InlineData('\r')]
        [InlineData('\f')]
        [InlineData('\v')]
        [InlineData('\\')]
        [InlineData('\'')]
        [InlineData('\"')]
        public void GetHashComandCombinationsCharsTest(char str)
        {
            try
            {
                PasswordHasher.Init("salt", 1);
                string firstHash = PasswordHasher.GetHash(str.ToString());
                string secondHash = PasswordHasher.GetHash(str.ToString());
                Assert.Equal(firstHash, secondHash);
            }
            catch (Exception exption)
            {
                Console.WriteLine(exption);
                Assert.True(false);
            }

        }
    }

    [Collection("full coverage tests")]
    public class PasswordHasherFullCoverageTests
    {
        [Theory]
        [InlineData(" 93 ", 93, "asdasd")]
        [InlineData(" 93 ", 93, "!@#$%^&.,`*()_+>-=<?:;~/[]{}")]
        [InlineData(" ", 1, "asdas")]
        [InlineData(" DsQfFS ііі ЇЇЇ їїї \n ", 0, "asdas")]
        [InlineData("!@#$%^&.,`*()_+>-=<?:;~/[]{}", 0, "!@#$%^&.,`*()_+>-=<?:;~/[]{}")]
        [InlineData(" ", 0, "!@#$%^&.,`*()_+>-=<?:;~/[]{}")]
        [InlineData(" \t \a \b \f \r \v \\ ", UInt32.MaxValue, "!@#$%^&.,`*()_+>-=<?:;~/[]{}")]
        [InlineData(" ", 0, " ")]
        [InlineData(" ", UInt32.MaxValue, " ")]
        [InlineData("1 d dsa sd G GDF S SDF SDF  sf1df%$sdЇ               ", 100, "ФІВЦЙУЫЇЁЮ")]
        [InlineData("                          ", 101, "Любі друзі, я вас вітаю і використовую символ Ї")]
        [InlineData("[{*()< d as1112356>d>?}]", 1000, "[{*()< d as1112356>d>?}]")]
        [InlineData("", 12.23, "")]
        [InlineData("", 12.23, "ASFDGREHWQWEMCNV")]
        [InlineData("", 0, "ASFDGREHWQWEMCNV")]
        [InlineData("asdas", UInt32.MaxValue, "ASFDGREHWQWEMCNV")]
        public void FullCoverageTestWithInit(string salt, UInt32 adler, string toHash)
        {
            try
            {
                PasswordHasher.Init(salt, adler);
                string firstHash = PasswordHasher.GetHash(toHash);
                string secondHash = PasswordHasher.GetHash(toHash);
                Assert.Equal(firstHash, secondHash);
            }
            catch (Exception exption)
            {
                Console.WriteLine(exption);
                Assert.True(false);
            }

        }

        [Theory]
        [InlineData(" 93 ", 93, "asdasd")]
        [InlineData(" 93 ", 93, "!@#$%^&.,`*()_+>-=<?:;~/[]{}")]
        [InlineData(" ", 1, "asdas")]
        [InlineData(" DsQfFS ііі ЇЇЇ їїї \n ", 0, "asdas")]
        [InlineData("!@#$%^&.,`*()_+>-=<?:;~/[]{}", 0, "!@#$%^&.,`*()_+>-=<?:;~/[]{}")]
        [InlineData(" ", 0, "!@#$%^&.,`*()_+>-=<?:;~/[]{}")]
        [InlineData(" \t \a \b \f \r \v \\ ", UInt32.MaxValue, "!@#$%^&.,`*()_+>-=<?:;~/[]{}")]
        [InlineData(" ", 0, " ")]
        [InlineData(" ", UInt32.MaxValue, " ")]
        [InlineData("1 d dsa sd G GDF S SDF SDF  sf1df%$sdЇ               ", 100, "ФІВЦЙУЫЇЁЮ")]
        [InlineData("                          ", 101, "Любі друзі, я вас вітаю і використовую символ Ї")]
        [InlineData("[{*()< d as1112356>d>?}]", 1000, "[{*()< d as1112356>d>?}]")]
        [InlineData("", 12.23, "")]
        [InlineData("", 12.23, "ASFDGREHWQWEMCNV")]
        [InlineData("", 0, "ASFDGREHWQWEMCNV")]
        [InlineData("asdas", UInt32.MaxValue, "ASFDGREHWQWEMCNV")]
        public void FullCoverageTestWithoutInit(string salt, UInt32 adler, string toHash)
        {
            try
            {
                //PasswordHasher.Init(salt, adler);
                string firstHash = PasswordHasher.GetHash(toHash, salt, adler);
                string secondHash = PasswordHasher.GetHash(toHash, salt, adler);
                Assert.Equal(firstHash, secondHash);
            }
            catch (Exception exption)
            {
                Console.WriteLine(exption);
                Assert.True(false);
            }

        }
    }
}

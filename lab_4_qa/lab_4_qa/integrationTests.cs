using IIG.CoSFE.DatabaseUtils;
using IIG.PasswordHashingUtils;
using IIG.FileWorker;
using IIG.BinaryFlag;
using System;
using Xunit;

namespace integrationTests.SqlConn
{

	public class InOutTests_MultipleBinaryFlagAndDB
	{
		FlagpoleDatabaseUtils conn;
		public InOutTests_MultipleBinaryFlagAndDB()
		{
			conn = DBConnConfig.GetDBConnection();
		}

		[Theory]

		[InlineData(2, true)]
		[InlineData(3, true)]
		[InlineData(101, true)]
		[InlineData(123123, true)]

		[InlineData(2, false)]
		[InlineData(3, false)]
		[InlineData(101, false)]
		[InlineData(123123, false)]
		public void OneInOutTest_defaultFlagVal(ulong len, bool startVal)
        {
			try
			{
				MultipleBinaryFlag f = new MultipleBinaryFlag(len, startVal);
				bool flagVal = f.GetFlag() ?? false;

				int? insertagFlagId = conn.AddFlag(f.ToString(), flagVal);
				if (insertagFlagId.Equals(null)) Assert.True(false);

				string outFlagString;
				bool? outFlagVal;
				int lastFlagId = insertagFlagId.Value;

				bool getFlagRes = conn.GetFlag(lastFlagId, out outFlagString, out outFlagVal);
				if (!getFlagRes) Assert.True(false);

				if (outFlagString != f.ToString()) Assert.True(false);
				if (outFlagVal != f.GetFlag()) Assert.True(false);
			}
			catch (Exception)
			{
				Assert.True(false);
			}

			Assert.True(true);

		}

		[Theory]
		[InlineData(3)]
		[InlineData(2)]
		[InlineData(101)]
		[InlineData(123123)]
		public void OneInOutTest_flagWithFalseParts(ulong len)
		{
			try
			{
				MultipleBinaryFlag f = new MultipleBinaryFlag(len, true);
				f.ResetFlag(0);
				f.ResetFlag(len / 2);
				f.ResetFlag(len - 1);

				bool flagVal = f.GetFlag() ?? false;

				int? insertagFlagId = conn.AddFlag(f.ToString(), flagVal);
				if (insertagFlagId.Equals(null)) Assert.True(false);

				string outFlagString;
				bool? outFlagVal;
				int lastFlagId = insertagFlagId.Value;

				bool getFlagRes = conn.GetFlag(lastFlagId, out outFlagString, out outFlagVal);
				if (!getFlagRes) Assert.True(false);

				if (outFlagString != f.ToString()) Assert.True(false);
				if (outFlagVal != f.GetFlag()) Assert.True(false);
			}
			catch (Exception)
			{
				Assert.True(false);
			}

			Assert.True(true);

		}

		[Theory]
		[InlineData(3)]
		[InlineData(2)]
		[InlineData(101)]
		[InlineData(123123)]
		public void OneInOutTest_flagWithTrueParts(ulong len)
		{
			try
			{
				MultipleBinaryFlag f = new MultipleBinaryFlag(len, false);
				f.SetFlag(0);
				f.SetFlag(len / 2);
				f.SetFlag(len - 1);

				bool flagVal = f.GetFlag() ?? false;

				int? insertagFlagId = conn.AddFlag(f.ToString(), flagVal);
				if (insertagFlagId.Equals(null)) Assert.True(false);

				string outFlagString;
				bool? outFlagVal;
				int lastFlagId = insertagFlagId.Value;

				bool getFlagRes = conn.GetFlag(lastFlagId, out outFlagString, out outFlagVal);
				if (!getFlagRes) Assert.True(false);

				if (outFlagString != f.ToString()) Assert.True(false);
				if (outFlagVal != f.GetFlag()) Assert.True(false);
			}
			catch (Exception)
			{
				Assert.True(false);
			}

			Assert.True(true);

		}

		[Theory]

		[InlineData(0, true)]
		[InlineData(1, true)]
		[InlineData(ulong.MinValue, true)]
		[InlineData(ulong.MaxValue, true)]

		[InlineData(0, false)]
		[InlineData(1, false)]
		[InlineData(ulong.MinValue, false)]
		[InlineData(ulong.MaxValue, false)]

		[InlineData(null, false)]
		[InlineData(null, true)]
		[InlineData(5, null)]
		[InlineData(1, null)]
		[InlineData(0, null)]
		[InlineData(ulong.MinValue, null)]
		[InlineData(ulong.MaxValue, null)]
		[InlineData(null, null)]
		public void OneInOutTest_InvalidArgs(ulong len, bool startVal)
		{
			try
			{
				MultipleBinaryFlag f = new MultipleBinaryFlag(len, startVal);
				bool flagVal = f.GetFlag() ?? false;

				int? insertagFlagId = conn.AddFlag(f.ToString(), flagVal);
				if (insertagFlagId.Equals(null)) Assert.True(true);

				string outFlagString;
				bool? outFlagVal;
				int lastFlagId = insertagFlagId.Value;

				bool getFlagRes = conn.GetFlag(lastFlagId, out outFlagString, out outFlagVal);
				if (!getFlagRes) Assert.True(false);

				if (outFlagString != f.ToString()) Assert.True(false);
				if (outFlagVal != f.GetFlag()) Assert.True(false);

				Assert.True(false);
			}
			catch (Exception)
			{
				Assert.True(true);
			}

		}

	}

	public class InOutTests_FileWorkerAndPasswordHasher
	{

		[Theory]
		[InlineData(" 93 ", 93, "asdasd", "./testFile.txt")]
		[InlineData(" 93 ", 93, "!@#$%^&.,`*()_+>-=<?:;~/[]{}", "./1.txt")]
		[InlineData(" ", 1, "asdas", "./testFile.txt")]
		[InlineData(" DsQfFS ііі ЇЇЇ їїї \n ", 0, "asdas", "./testFile.txt")]
		[InlineData("!@#$%^&.,`*()_+>-=<?:;~/[]{}", 0, "!@#$%^&.,`*()_+>-=<?:;~/[]{}", "./1 1.txt")]
		[InlineData(" ", 0, "!@#$%^&.,`*()_+>-=<?:;~/[]{}", "./testFile.txt")]
		[InlineData(" \t \a \b \f \r \v \\ ", UInt32.MaxValue, "!@#$%^&.,`*()_+>-=<?:;~/[]{}", "./якийсьТамФаёлї.txt")]
		[InlineData(" ", 0, " ", "./1234567890_ніби працює.txt")]
		[InlineData(" ", UInt32.MaxValue, " ", "./в мене закінчуються ідеї.txt")]
		[InlineData("1 d dsa sd G GDF S SDF SDF  sf1df%$sdЇ               ", 100, "ФІВЦЙУЫЇЁЮ", "./!.txt")]
		[InlineData("                          ", 101, "Любі друзі, я вас вітаю і використовую символ Ї", "./.файл.txt")]
		[InlineData("[{*()< d as1112356>d>?}]", 1000, "[{*()< d as1112356>d>?}]", "./фівфів.asm.txt")]
		[InlineData("", 12.23, "", "./@@.txt")]
		[InlineData("", 12.23, "ASFDGREHWQWEMCNV", "./##.txt")]
		[InlineData("", 0, "ASFDGREHWQWEMCNV", "./%$.txt")]
		[InlineData("asdas", UInt32.MaxValue, "ASFDGREHWQWEMCNV", "./^&()_-'`;+=!.txt")]
		public void OneInOutTest_trueArgs(string salt, UInt32 adler, string toHash, string fullPathToFile)
		{
			try
			{
				PasswordHasher.Init(salt, adler);
				string hash = PasswordHasher.GetHash(toHash);

				bool writeRes = BaseFileWorker.Write(hash, fullPathToFile);
				if (!writeRes) Assert.True(false);

				string readRes = BaseFileWorker.ReadAll(fullPathToFile);
				if (readRes != hash) Assert.True(false);

			}
			catch (Exception)
			{
				Assert.True(false);
			}

			Assert.True(true);

		}

		[Theory]
		[InlineData("asdasd")]
		[InlineData("")]
		[InlineData(null)]
		[InlineData("[{*()< d as1112356>d>?}]")]
		[InlineData("./")]
		[InlineData(".\\")]
		[InlineData("asdasd.")]
		[InlineData(" ")]
		[InlineData("lol.kekw")]
		[InlineData(" \t \a \b \f \r \v \\ ")]
		[InlineData("Любі друзі, я вас вітаю і використовую символ Ї.txt")]
		[InlineData("asda.jpg")]
		[InlineData(".txt")]
		[InlineData("./.txt")]
		[InlineData("./ .txt")]
		[InlineData(".\\ .txt")]
		[InlineData(".//txt")]
		[InlineData("\n arrrr.txt")]
		[InlineData("1. txt")]
		[InlineData("1.asm")]

		public void OneInOutTest_wrongFilePathTests(string path)
		{
			try
			{
				PasswordHasher.Init("99", 1);
				string hash = PasswordHasher.GetHash("string");

				bool writeRes = BaseFileWorker.Write(hash, path);
				if (writeRes) Assert.True(false);

				string readRes = BaseFileWorker.ReadAll(path);
				if (readRes != hash) Assert.True(false);

				Assert.True(false);
			}
			catch (Exception)
			{
				Assert.True(true);
			}

			Assert.True(true);

		}
	}
}

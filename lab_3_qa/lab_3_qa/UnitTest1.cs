using System;
using Xunit;
using IIG.BinaryFlag;

namespace BinaryFlagTests
{
    [Collection("Constructors tests")]
    public class BinaryFlagConstructorTests
    {
        [Fact]
        public void Route_0_1_2_9()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(0, true);
                Assert.True(false);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Route_0_3_2_9()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(99999999999, true);
                Assert.True(false);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Route_0_1_3_4_6_9()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(4, true);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_3_4_5_7_9()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(55, true);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_3_4_5_8_9()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(66, true);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }
    }

    [Collection("Constructors tests")]
    public class UIntConcreteBinaryFlagConstructorTests
    {
        [Fact]
        public void Route_0_1_3_4_5_7()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(3, true);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_3_4_5_6_7()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(3, false);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }
    }

    [Collection("Constructors tests")]
    public class UlongConcreteBinaryFlagConstructorTests
    {
        [Fact]
        public void Route_0_1_3_4_5_7()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(45, true);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_3_4_5_6_7()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(45, false);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }
    }

    [Collection("Constructors tests")]
    public class UIntArrayConcreteBinaryFlagConstructorTests
    {
        [Fact]
        public void Route_0_1_3_4_5_6_7_11()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(150, true);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_3_4_5_6_7_8_9_11()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(150, false);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }
    }

    [Collection("Dispose tests")]
    public class UIntConcreteBinaryFlagDisposeTests
    {
        [Fact]
        public void Route_0_1_19()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(11, false);
                b.Dispose();
                b.Dispose();
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Route_0_1_2_3_4_5_6_7_8_9_10_11_15_16_17_18_19()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(11, false);
                b.Dispose();
                b.SetFlag(2);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }

    [Collection("Dispose tests")]
    public class UlongConcreteBinaryFlagDisposeTests
    {
        [Fact]
        public void Route_0_1_19()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(45, false);
                b.Dispose();
                b.Dispose();
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Route_0_1_2_3_4_5_6_7_8_9_10_11_15_16_17_18_19()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(45, false);
                b.Dispose();
                b.SetFlag(2);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }

    [Collection("Dispose tests")]
    public class UIntArrayConcreteBinaryFlagDisposeTests
    {
        [Fact]
        public void Route_0_1_19()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(666, false);
                b.Dispose();
                b.Dispose();
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Route_0_1_2_3_4_5_6_7_8_9_10_11_15_16_17_18_19()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(666, false);
                b.Dispose();
                b.SetFlag(2);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }

    [Collection("SetFlag tests")]
    public class UIntConcreteBinaryFlagSetFlagTests
    {
        [Fact]
        public void Route_0_1_2_4_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(11, false);
                b.SetFlag(2);
                string res = string.Join(string.Empty, b.ToString()[2]);
                Assert.Equal("T", res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_2_3_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(11, false);
                b.SetFlag(13);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Route_0_1_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(11, false);
                b.Dispose();
                b.SetFlag(5);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }

    [Collection("SetFlag tests")]
    public class UlongConcreteBinaryFlagSetFlagTests
    {
        [Fact]
        public void Route_0_1_2_4_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(45, false);
                b.SetFlag(2);
                string res = string.Join(string.Empty, b.ToString()[2]);
                Assert.Equal("T", res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_2_3_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(45, false);
                b.SetFlag(55);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Route_0_1_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(45, false);
                b.Dispose();
                b.SetFlag(5);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }

    [Collection("SetFlag tests")]
    public class UIntArrayConcreteBinaryFlagSetFlagTests
    {
        [Fact]
        public void Route_0_1_2_4_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(666, false);
                b.SetFlag(2);
                string res = string.Join(string.Empty, b.ToString()[2]);
                Assert.Equal("T", res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_2_3_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(666, false);
                b.SetFlag(777);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Route_0_1_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(666, false);
                b.Dispose();
                b.SetFlag(5);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }

    [Collection("ResetFlag tests")]
    public class UIntConcreteBinaryFlagResetFlagTests
    {
        [Fact]
        public void Route_0_1_2_4_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(11, true);
                b.ResetFlag(2);
                string res = string.Join(string.Empty, b.ToString()[2]);
                Assert.Equal("F", res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_2_3_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(11, true);
                b.ResetFlag(13);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Route_0_1_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(11, true);
                b.Dispose();
                b.ResetFlag(5);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }

    [Collection("ResetFlag tests")]
    public class UlongConcreteBinaryFlagResetFlagTests
    {
        [Fact]
        public void Route_0_1_2_4_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(45, true);
                b.ResetFlag(2);
                string res = string.Join(string.Empty, b.ToString()[2]);
                Assert.Equal("F", res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_2_3_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(45, true);
                b.ResetFlag(55);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Route_0_1_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(45, true);
                b.Dispose();
                b.ResetFlag(5);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }

    [Collection("ResetFlag tests")]
    public class UIntArrayConcreteBinaryFlagResetFlagTests
    {
        [Fact]
        public void Route_0_1_2_4_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(666, true);
                b.ResetFlag(2);
                string res = string.Join(string.Empty, b.ToString()[2]);
                Assert.Equal("F", res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_2_3_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(666, true);
                b.ResetFlag(777);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Route_0_1_5()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(666, true);
                b.Dispose();
                b.ResetFlag(5);
                Assert.True(false);
            }
            catch (Exception)
            {
                Assert.True(true);
            }
        }
    }

    [Collection("GetFlag tests")]
    public class UIntConcreteBinaryFlagGetFlagTests
    {
        [Fact]
        public void Route_0_1_3()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(11, false);
                b.Dispose();
                bool? res = b.GetFlag();
                Assert.Null(res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_2_true()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(11, true);
                bool? res = b.GetFlag();
                Assert.Equal(true, res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_2_false()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(11, false);
                bool? res = b.GetFlag();
                Assert.Equal(false, res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }
    }

    [Collection("GetFlag tests")]
    public class UlongConcreteBinaryFlagGetFlagTests
    {
        [Fact]
        public void Route_0_1_3()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(45, false);
                b.Dispose();
                bool? res = b.GetFlag();
                Assert.Null(res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_2_true()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(45, true);
                bool? res = b.GetFlag();
                Assert.Equal(true, res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_2_false()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(45, false);
                bool? res = b.GetFlag();
                Assert.Equal(false, res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }
    }

    [Collection("GetFlag tests")]
    public class UIntArrayConcreteBinaryFlagGetFlagTests
    {
        [Fact]
        public void Route_0_1_3()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(666, false);
                b.Dispose();
                bool? res = b.GetFlag();
                Assert.Null(res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_2_true()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(666, true);
                bool? res = b.GetFlag();
                Assert.Equal(true, res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Route_0_1_2_false()
        {
            try
            {
                MultipleBinaryFlag b = new MultipleBinaryFlag(666, false);
                bool? res = b.GetFlag();
                Assert.Equal(false, res);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }
    }
}

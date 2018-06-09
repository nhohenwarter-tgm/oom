using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task6
{
    class ServerTests
    {

        [Test]
        public void TestCpuTypeNull()
        {
            Assert.Catch(() =>
            {
                new Server(null, 2400, 128, 4959.90m, "serv01", 2);
            });
        }

        [Test]
        public void TestCpuTypeEmpty()
        {
            Assert.Catch(() =>
            {
                new Server("", 2400, 128, 4959.90m, "serv01", 2);
            });
        }

        [Test]
        public void TestDiskSpaceLessThanZero()
        {
            Assert.Catch(() =>
            {
                new Server("Intel Xeon E7-8855 v4", -10, 128, 4959.90m, "serv01", 2);
            });
        }

        [Test]
        public void TestDiskSpaceZero()
        {
            Assert.Catch(() =>
            {
                new Server("Intel Xeon E7-8855 v4", 0, 128, 4959.90m, "serv01", 2);
            });
        }

        [Test]
        public void TestRAMLessThanZero()
        {
            Assert.Catch(() =>
            {
                new Server("Intel Xeon E7-8855 v4", 2400, -10, 4959.90m, "serv01", 2);
            });
        }

        [Test]
        public void TestRAMZero()
        {
            Assert.Catch(() =>
            {
                new Server("Intel Xeon E7-8855 v4", 2400, 0, 4959.90m, "serv01", 2);
            });
        }

        [Test]
        public void TestPriceLessThanZero()
        {
            Assert.Catch(() =>
            {
                new Server("Intel Xeon E7-8855 v4", 2400, 128, -10.0m, "serv01", 2);
            });
        }

        [Test]
        public void TestPriceZero()
        {
            Assert.Catch(() =>
            {
                new Server("Intel Xeon E7-8855 v4", 2400, 128, 0.0m, "serv01", 2);
            });
        }

        [Test]
        public void TestHostnameNull()
        {
            Assert.Catch(() =>
            {
                new Server("Intel Xeon E7-8855 v4", 2400, 128, 4959.90m, null, 2);
            });
        }

        [Test]
        public void TestHostnameEmpty()
        {
            Assert.Catch(() =>
            {
                new Server("Intel Xeon E7-8855 v4", 2400, 128, 4959.90m, "", 2);
            });
        }

        [Test]
        public void TestHELessThanZero()
        {
            Assert.Catch(() =>
            {
                new Server("Intel Xeon E7-8855 v4", 2400, 128, 4959.90m, "serv01", -10);
            });
        }

        [Test]
        public void TestHEZero()
        {
            Assert.Catch(() =>
            {
                new Server("Intel Xeon E7-8855 v4", 2400, 128, 4959.90m, "serv01", 0);
            });
        }

        [Test]
        public void TestOk()
        {
            Assert.Catch(() =>
            {
                new Server("Intel Xeon E7-8855 v4", 2400, 128, 4959.90m, "serv01", 0);
            });
        }
    }
}

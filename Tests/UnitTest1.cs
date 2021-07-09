using Logic_Layer;
using System;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestPartitaAttack()
        {
            Partita partita = new Partita();
            double res=partita.print("Limoni", 50, 80, "vita");
            Assert.Equal(30, res);
        }
        [Fact]
        public void TestPartitaLifePoint()
        {
            Partita partita = new Partita();
            double lp = partita.LifePoint(3);
            Assert.Equal((double)60, lp);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using kbs1b;

namespace KBS1BTest {

    [TestClass]
    public class KBS1BTest {


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "index out of range")]
        public void valideAanmaakObstakel() {
            Obstacle ob1 = new Obstacle(2, 100, 100, 50, 1); // Valide aanmaak stilstaand obstacle MIN
            Obstacle ob2 = new Obstacle(2, 200, 100, 50, 4); // Valide aanmaak achtervolgende obstacle MAX
            Input input = new Input('w', 'a', 's', 'd', 'p');
            Player player = new Player(input);


            Assert.AreEqual(1, ob1.behaviour); // test dat behaviour van ob1 gelijk is aan 1
            Assert.AreEqual(4, ob2.behaviour); // test dat behaviour van ob2 gelijk is aan 4
            Obstacle ob3 = new Obstacle(2, 300, 100, 50, 0); // niet valide aanmaak obstacle, gooit IndexOutOfRangeException
            Obstacle ob4 = new Obstacle(2, -1, 100, 50, 1); // niet valide aanmaak obstacle, gooit IndexOutOfRangeException
            Obstacle ob5 = new Obstacle(2, 100, -1, 50, 1); // niet valide aanmaak obstacle, gooit IndexOutOfRangeException


        }

        [TestMethod]
        public void verticaleMovementObstakel() {
            int yMax = 500;
            bool richtingDown = true;
            Obstacle ob1 = new Obstacle(2, 100, 100, 50, 2);

            ob1.vertical_move(ref yMax, ref richtingDown);

            Assert.AreEqual(102, ob1.YPOS);// test dat obstacle Y positie 2 pixels is verhoogd
        }

        [TestMethod]
        public void horizontaleMovementObstakel() {
            int xMax = 500;
            bool richtingDown = true;
            Obstacle ob1 = new Obstacle(2, 100, 100, 50, 3);

            ob1.horizontal_move(ref xMax, ref richtingDown);

            Assert.AreEqual(102, ob1.XPOS);// test dat obstacle X positie 2 pixels is verhoogd
        }

    }
}

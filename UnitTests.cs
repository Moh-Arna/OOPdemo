namespace Asg5
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void EmployeeEmptyConstructor()
        {
            try
            {
                Employee e = new Employee();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        [TestMethod]
        public void EmployeeConsShortEmpID()
        {
            try
            {
                Employee e = new Employee("Mike C", 000123);
            }
            catch (Exception e)
            {
                return;
            }
            Assert.Fail("Employee ID needs to be 5 or 6 characters long: 000123 should not be allowed in the constructor.");
        }

        [TestMethod]
        public void EmployeeConsShortEmpID2()
        {
            try
            {
                Employee e = new Employee("Mike C", 002034);
            }
            catch (Exception e)
            {
                return;
            }
            Assert.Fail("Employee ID needs to be 5 or 6 characters long: 002034 should not be allowed in the constructor");
        }

        [TestMethod]
        public void EmployeeCons2Param()
        {
            try
            {
                string name = "Mike C";
                uint id = 934024;
                Employee e = new Employee(name, id);
                Assert.IsTrue(e.Name.Contains(name) && e.IdNumber == id);
            }
            catch (Exception e)
            {
                Assert.Fail("Employee ID should accept 5 or 6 characters long.");
            }
        }

        [TestMethod]
        public void EmployeeCons4Param()
        {
            try
            {
                string name = "Mike C", position = "Vice-President", department = "IT";
                uint id = 93402;
                Employee e = new Employee(name, id, department, position);

                Assert.IsTrue(e.ToString().Contains(name) &&
                            e.ToString().Contains(id.ToString()) &&
                            e.ToString().Contains(department) &&
                            e.ToString().Contains(position));
            }
            catch (Exception e)
            {
                Assert.Fail("Employee ID should accept 5 or 6 characters long.");
            }
        }

        [TestMethod]
        public void EmployeeDepartmentDigit()
        {
            try
            {
                Employee e = new Employee("Mike C", 12034, "CS 4", "Junior");
            }
            catch (Exception e)
            {
                return;
            }
            Assert.Fail("Department should not contain any digits.");
        }

        [TestMethod]
        public void EmployeePositionDigit()
        {
            try
            {
                Employee e = new Employee("Mike C", 12034, "CS", "Junior 5");
            }
            catch (Exception e)
            {
                return;
            }
            Assert.Fail("The Position should not contain any digits.");
        }

        [TestMethod]
        public void EmployeeNameDigit()
        {
            try
            {
                Employee e = new Employee("Mike C 5", 12034, "CS", "Junior");
            }
            catch (Exception e)
            {
                return;
            }
            Assert.Fail("The name should not contain any digits.");
        }



        [TestMethod]
        public void EmployeePropIDShort()
        {
            try
            {
                Employee e = new Employee();

                e.IdNumber = 01023;
            }
            catch (Exception e)
            {
                return;
            }

            Assert.Fail("Employee ID needs to be 5 or 6 characters long: 01023 should not be allowed.");
        }

        [TestMethod]
        public void EmployeePropIDGood()
        {
            try
            {
                uint id = 11023;
                Employee e = new Employee();

                e.IdNumber = id;
                Assert.AreEqual(e.IdNumber, id);

            }
            catch (Exception e)
            {
                Assert.Fail("Employee ID should accept 5 or 6 characters long.");
            }


        }

        [TestMethod]
        public void EmployeePropName()
        {
            try
            {
                Employee e = new Employee("Mike", 12345);
                e.Name = "Mike C";
                Assert.AreEqual(e.Name, "Mike C");
            }
            catch (Exception e)
            {
                Assert.Fail("Name Property Set issues.");
            }
        }

        [TestMethod]
        public void EmployeePropDepartment()
        {
            try
            {
                Employee e = new Employee();
                e.Department = "Legal";
            }
            catch (Exception e)
            {
                Assert.Fail("Department Property Set issues.");
            }
        }

        [TestMethod]
        public void EmployeePropPosition()
        {
            try
            {
                string position = "Engineering Director";
                Employee e = new Employee();
                e.Position = position;
                Assert.AreEqual(e.Position, position);
            }
            catch (Exception e)
            {
                Assert.Fail("Position Property Set issues.");
            }
        }

        [TestMethod]
        public void EmployeeToString()
        {
            string name = "Mike C", position = "Vice-President", department = "IT";
            uint id = 93402;
            Employee e = new Employee(name, id, department, position);

            Assert.IsTrue(e.ToString().Contains(name) &&
                            e.ToString().Contains(id.ToString()) &&
                            e.ToString().Contains(department) &&
                            e.ToString().Contains(position));
        }

        [TestMethod]
        public void CarAccelerate()
        {
            Car c = new Car();
            if (c.FuelLevel == 0) c.Refill();

            int max = 160 / 5;

            for (int i = 1; i <= max + 2; i++)
            {
                c.Accelerate();
            }

            //fuel level 32%. speed is 160
            Assert.AreEqual(160, c.Speed);
        }

        [TestMethod]
        public void CarFuel1()
        {
            Car c = new Car();

            if (c.FuelLevel == 0) c.Refill();

            int max = 160 / 5;

            for (int i = 1; i <= max + 2; i++)
            {
                c.Accelerate();
            }

            //fuel level 32%. speed is 160
            Assert.AreEqual(32, c.FuelLevel);
        }

        [TestMethod]
        public void CarFuel2()
        {
            Car c = new Car();
            if (c.FuelLevel == 0) c.Refill();

            int max = 160 / 5;

            for (int i = 1; i <= max + 2; i++)
            {
                c.Accelerate();
            }
            c.Brake();
            c.Brake();

            //Assert.AreEqual(30, c._fuelLevel);       
            Assert.AreEqual(30, c.FuelLevel);
        }

        [TestMethod]
        public void CarOutOfFuel()
        {
            Car c = new Car();

            Assert.AreEqual(0, c.Speed);
        }

        [TestMethod]
        public void CarFuelEmpty()
        {
            Car c = new Car();
            int max = 100;

            for (int i = 1; i <= max; i++)
            {
                c.Accelerate();
            }
            //c.Break();
            //c.Break();

            //Assert.AreEqual(0, c._fuelLevel);
            Assert.AreEqual(0, c.FuelLevel, "Fuel should be reduced when Accelerating even if the car is at top speed. ");
        }

        [TestMethod]
        public void CarOutOfRangeYearModelMinFail()
        {
            //Year 1884 is not accepted
            try
            {
                Car c = new Car(1885, "Steam Power Locomotive car");
                c.YearModel = 1885;
            }
            catch (Exception e)
            {
                return;
            }

            Assert.Fail("Car year out of Min range");
        }
        [TestMethod]
        public void CarOutOfRangeYearModelMinOK()
        {
            //Year 1885 is accepted
            try
            {
                Car c = new Car(1886, "Steam Power Locomotive car");
                c.YearModel = 1886;
                Assert.IsTrue(c.ToString().Contains("1886") || c.YearModel == 1886);
            }
            catch (Exception e)
            {
                Assert.Fail("Car year is in range");
            }

            return;
        }

        [TestMethod]
        public void CarOutOfRangeYearModelMaxOK()
        {
            try
            {
                ushort fiveYearsLater = (ushort)(DateTime.Now.Year + 5);
                Car c = new Car(fiveYearsLater, "Future car");
                c.YearModel = fiveYearsLater;
                Console.WriteLine($"Year model: {c.YearModel} Good: {fiveYearsLater}");

                Assert.AreEqual(c.YearModel, fiveYearsLater);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error {e.Message}");
                Assert.Fail("Car year is in range");
            }

            return;
        }

        [TestMethod]
        public void CarOutOfRangeYearModelMaxFail()
        {
            try
            {
                ushort sixYearsLater = (ushort)(DateTime.Now.Year + 6);
                Car c = new Car(sixYearsLater, "Wind Power Locomotive Car");
                c.YearModel = sixYearsLater;
            }
            catch (Exception e)
            {
                return;
            }

            Assert.Fail("Car year out of Max range");
        }

        [TestMethod]
        public void CarFuelEmpty2()
        {
            Car c = new Car();
            int max = 50;

            for (int i = 1; i <= max; i++)
            {
                c.Accelerate();
            }

            //c.Brake();
            //c.Brake();

            //Assert.AreEqual(0, c._fuelLevel);
            Assert.AreEqual(0, c.FuelLevel, "Fuel should be reduced when Accelerating even if the car is at top speed. ");        //CORRECT
        }

        //Test when it accelerate past the max speed. 
        //When fuel is 0, loops back to 255 for short.

        [TestMethod]
        public void CarFuelEmpty3()
        {
            Car c = new Car();
            int max = 53;

            for (int i = 1; i <= max; i++)
            {
                c.Accelerate();
            }

            //c.Brake();
            //c.Brake();

            Assert.AreEqual(0, c.Speed, "When fuel is 0, it should not loop back to 255 for short.");    //CORRECT 
        }


        [TestMethod]
        public void CarRefuel()
        {
            Car c = new Car();
            int max = 51;

            for (int i = 1; i <= max; i++)
            {
                c.Accelerate();
            }

            for (int i = 1; i <= max; i++)
            {
                c.Brake();
            }

            c.Refill();     //get speed to 0 before refuel 

            Assert.AreEqual(100, c.FuelLevel);
        }

        [TestMethod]
        public void CarToString()
        {
            string model = "Tesla Model X";
            Car c = new Car((ushort)(DateTime.Now.Year + 1), model);

            Assert.IsTrue(c.ToString().Contains(c.Speed.ToString()) &&
                        c.ToString().Contains(c.YearModel.ToString()) &&
                        c.ToString().Contains(model));
        }

        [TestMethod]
        public void CarMake()
        {
            Car c = new Car((ushort)(DateTime.Now.Year + 1), "Tesla Model X");
            c.Make = "Tesla Model 3";
            //Car c = new Car("Tesla Model X", 2021);

            Assert.IsTrue(c.Make.Contains("Tesla Model 3"));
        }
    }
        
}
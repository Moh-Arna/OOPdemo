/*
 * Programming 2 - Assignment 5 - Winter 2026
 * Created by: Mohammad Arnaout & 2576053
 * Tested by: Hamza (cousin)
 * Date: April 25th, 2026
 * The goal of this class is to "model" a Car with a year, make, speed, and fuel level.
 * It'll also have functionality for acceleration, braking, and refilling with proper validation checking.
 */

using Microsoft.Testing.Platform.Extensions.TestHostControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asg5
{
    public class Car
    {

        #region Fields

        // Fields are private to the class
        private ushort _yearModel;
        private string _make;
        private byte _speed;
        private byte _fuelLevel;

        // Constants for no magic numbers
        private const byte MaxSpeed = 160;
        private const byte MinSpeed = 0;
        private const byte SpeedInc = 5;

        private const byte MaxFuel = 100;
        private const byte MinFuel = 0;
        private const byte FuelDecAccelerate = 2;
        private const byte FuelDecBrake = 1;

        private const ushort MinYearModel = 1886;
        private const int MaxYearOffset = 5; // current year + 5 max

        #endregion

        #region Constructors

        // Default constructor, year model is 0, make is empty, speed is 0, and fuel is set to 0.
        public Car()
        {
            _yearModel = 0;
            _make = string.Empty;
            _speed = 0;
            _fuelLevel = 0;
        }

        // Param's constructor, year + make are given, but speed is set 0 and fuel is set to max.
        public Car(ushort yearModel, string make)
        {
            YearModel = yearModel;
            Make = make;
            _speed = 0;
            _fuelLevel = MaxFuel;
        }

        #endregion

        #region Properties
        
        // The year model has to be between 1886 and the current year + 5.
        // So we check if the value is smaller than the minimum, or if the value is bigger than the maximum
        // If it is, we'll throw an exception.
        public ushort YearModel
        {
            get { return _yearModel; }
            set
            {
                ushort maxYear = (ushort)(DateTime.Now.Year + MaxYearOffset);
                if (value < MinYearModel || value > maxYear)
                {
                    throw new ArgumentOutOfRangeException("YearModel", $"Year must be between {MinYearModel} and {maxYear}.");
                }
                _yearModel = value;
            }
        }

        // Make is just a get and a null operator to see if make is nill then make it empty.
        public string Make
        {
            get { return _make; }
            set { _make = value ?? string.Empty; }
        }
        
        // We only need to fetch it
        public byte Speed
        {
            get { return _speed; }
        }

        // We only need to fetch it
        public byte FuelLevel
        {
            get { return _fuelLevel; }
        }

        #endregion

        #region Methods

        // Accelerate function, +5 speed up until the max (160). Fuel still drops at top speed
        // If fuel is already at 0, do nothing
        public void Accelerate()
        {
            // If the fuel level is equal to 0 (or somehow smaller) then return. <= is redundant, it's just here to be safe
            if (_fuelLevel <= MinFuel) { return; }

            // Increase speed only if we won't exceed the maxspeed.
            if (_speed + SpeedInc <= MaxSpeed)
            {
                _speed = (byte)(_speed + SpeedInc);
            }

            // Always reduce fuel
            if (_fuelLevel >= FuelDecAccelerate)
            {
                _fuelLevel = (byte)(_fuelLevel - FuelDecAccelerate);
            }
            else // If fuel level is not bigger than or equal to how much the fuel decrements, then set it to the minimum (0)
            {
                _fuelLevel = MinFuel;
            }

            // When fuel runs out because of accelerating, speed drops to 0 immediately
            if (_fuelLevel == MinFuel)
            {
                _speed = MinSpeed;
            }

        }

        // Brake function, -5 speed (but never below 0), -1 fuel. Standing still OR no fuel = nothing happens.
        public void Brake()
        {

            // If the speed is equal or smaller than the minimum speed (somehow) we do nothing. <= is again redundant, just added to be safe.
            if (_speed <= MinSpeed)
            {
                return;
            }

            // If the fuel level is equal or smaller than minimum fuel (somehow) we do nothing. <= is again redundant, just added to be safe.
            if (_fuelLevel <= MinFuel)
            {
                return;
            }

            // Subtract 5 from speed, but if speed is less than 5 just set it to 0
            // so it doesn't go below the minimum
            if (_speed >= SpeedInc)
            {
                _speed = (byte)(_speed - SpeedInc);
            }
            else
            {
                _speed = MinSpeed;
            }

            // Subtract 1 from fuel, but if fuel is less than 1 just set it to 0
            // so it doesn't go below the minimum
            if (_fuelLevel >= FuelDecBrake)
            {
                _fuelLevel = (byte)(_fuelLevel - FuelDecBrake);
            }
            else
            {
                _fuelLevel = MinFuel;
            }

            // If the fuel just ran out, the car can't move anymore so set speed to 0
            if (_fuelLevel == MinFuel)
            {
                _speed = MinSpeed;
            }

        }

        // Refill, the function refills the fuel level to 100, but only if the car is stopped AND not at max fuel already
        public void Refill()
        {
            // The car is still moving because speed is over the minimum speed.
            if (_speed > MinSpeed)
            {
                throw new InvalidOperationException("Cannot refill while the car is moving.");
            }
            
            // The car has max fuel, so refilling would do nothing.
            if (_fuelLevel == MaxFuel)
            {
                throw new InvalidOperationException("Car is already at max fuel.");
            }

            // Passed both validation checks, we can therefore refill.
            _fuelLevel = MaxFuel;
        }

        // Returns a string with all the data (we're also overriding it as per the assignment instructions!!!)
        public override string ToString()
        {
            return $"Car: {_make} | Year: {_yearModel} | Speed: {_speed} | Fuel level: {_fuelLevel}%";
        }

        #endregion
    }
}   

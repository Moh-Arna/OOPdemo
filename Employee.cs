/*
 * Programming 2 - Assignment 5 - Winter 2026
 * Created by: Mohammad Arnaout & 2576053
 * Tested by: Hamza (Cousin)
 * Date: April 25th, 2026
 * The goal of this class is to "model" an Employee with an ID number, a name, a department and a position.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asg5
{
    public class Employee
    {
        #region Fields

        // Fields private to the class
        private uint _idNumber;
        private string _name;
        private string _department;
        private string _position;

        // Constants so no magic numbers
        private const uint MinIdValue = 10000; // smallest 5 dig number
        private const uint MaxIdValue = 999999; // largest 6 dig number
        #endregion

        #region Constructors

        // This is the default constructor, sets everything to empty / 0.
        public Employee()
        {
            _idNumber = 0;
            _name = string.Empty;
            _department = string.Empty;
            _position = string.Empty;
        }

        // Constructor with name and id only (2 params), and uses the Property for validation
        public Employee(string name, uint idNumber)
        {
            Name = name;
            IdNumber = idNumber;
            Department = string.Empty;
            Position = string.Empty;
        }

        // Constructor with all 4 values (4 params), and uses the Property for validation
        public Employee(string name, uint idNumber, string department, string position)
        {
            Name = name;
            IdNumber = idNumber;
            Department = department;
            Position = position;
        }

        #endregion

        #region Properties

        // IdNumber has to be 5 or 6 digits long, so we check if the value is below the MinIdValue or above the MaxIdValue.
        // If it is, then we throw an exception.
        public uint IdNumber { 
            get { return _idNumber; }
            set
            {
                if (value < MinIdValue || value > MaxIdValue)
                {
                    throw new ArgumentOutOfRangeException("IdNumber", "Employee ID must be 5 or 6 digits long");
                }
                _idNumber = value;
            }
        }

        // Name cannot contain digits, so we call the function HasDigit to validate.
        // If a digit is found, we throw an exception.
        public string Name
        {
            get { return _name; }
            set
            {
                if (HasDigit(value))
                {
                    throw new ArgumentException("Name cannot contain digits", "Name");
                }
                _name = value;
            }
        }

        // Department cannot contain digits, so we call the function HasDigit to validate.
        // If a digit is found, we throw an exception.
        public string Department
        {
            get { return _department; }
            set
            {
                if (HasDigit(value))
                {
                    throw new ArgumentException("Department cannot contain digits", "Department");
                }
                _department = value;
            }
        }

        // Position cannot contain digits, so we call the function HasDigit to validate.
        // If a digit is found, we throw an exception.
        public string Position
        {
            get { return _position; }
            set
            {
                if (HasDigit(value))
                {
                    throw new ArgumentException("Position cannot contain digits", "Position");
                }
                _position = value;
            }
        }

        #endregion

        #region Methods

        // Returns a string with all the data (we're also overriding it as per the assignment instructions!!!)
        public override string ToString()
        {
            return $"Employee: {_name} | ID: {_idNumber} | Department: {_department} | Position: {_position}";
        }

        // Helper that checks if a string has at least one digit
        private bool HasDigit(string text)
        {
            // If we don't have any text, return false
            if (text == null) return false;

            // go through each character in the string we got, and if it contains any digit return true.
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }

            // otherwise, we return false.
            return false;
        }

        #endregion
    }
}

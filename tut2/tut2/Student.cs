using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace tut2
{
    [XmlType("student")]
    [XmlInclude(typeof(Studies))]
    [Serializable]
    public class Student
    {
        [XmlElement(ElementName = "fname")]
        [JsonPropertyName("fname")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "lname")]
        [JsonPropertyName("lname")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "birthdate")]
        [JsonPropertyName("birthdate")]
        public string DateOfBirth { get; set; }

        [XmlElement(ElementName = "email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "mothersName")]
        [JsonPropertyName("mothersName")]
        public string MotherName { get; set; }

        [XmlElement(ElementName = "fathersName")]
        [JsonPropertyName("fathersName")]
        public string FatherName { get; set; }

        
        private string _studentNumber;
        [XmlAttribute(AttributeName = "indexNumber")]
        [JsonPropertyName("indexNumber")]
        public string StudentNumber {
            get
            {
                return _studentNumber;
            }
            set 
            {
                _studentNumber = $"s{value}";            
            } }

        [XmlElement(ElementName = "studies")]
        [JsonPropertyName("studies")]
        public Studies Studies { get; set; }

        
    }
}

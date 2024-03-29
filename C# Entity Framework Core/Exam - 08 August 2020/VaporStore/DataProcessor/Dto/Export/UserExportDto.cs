﻿using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{

    [XmlType("User")]
    public class UserExportDto
    {
        [XmlAttribute("username")]
        public string UserName { get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }

        [XmlArray("Purchases")]
        public PurchaseExportDto[] Purchases { get; set; }
    }
}

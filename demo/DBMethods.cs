﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
	internal class DBMethods
	{
		ClassAdo classAdo = new ClassAdo();

		string sqlTypePartner = "select * from Partners_type";

		public List<TypePartner> GetTypePartners()
		{
			List<TypePartner> typePartners = new List<TypePartner>();
			DataSet ds = classAdo.GetDataSet(sqlTypePartner);
			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				TypePartner typePartner = new TypePartner();
				typePartner.TypePartnerId = int.Parse(ds.Tables[0].Rows[i]["typePartnerId"].ToString());
				typePartner.TypePartnerName = ds.Tables[0].Rows[i]["typePartnerName"].ToString();
				typePartners.Add(typePartner);
			}
			return typePartners;
		}

		string sqlPartners = "select * from Partners, Partners_type where Partners_type.typePartnerId = Partners.typePartnerId";

		public List<Partners> GetPartners()
		{
			List<Partners> partners = new List<Partners>();
			DataSet ds = classAdo.GetDataSet(sqlPartners);
			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				Partners partners1 = new Partners();
				partners1.PartnerId = int.Parse(ds.Tables[0].Rows[i]["partnersId"].ToString());
				partners1.NamePartner = ds.Tables[0].Rows[i]["NamePartner"].ToString();
				partners1.Director = ds.Tables[0].Rows[i]["director"].ToString();
				partners1.EmailPartner = ds.Tables[0].Rows[i]["emailPartner"].ToString();
				partners1.PhonePartner = ds.Tables[0].Rows[i]["phonePartner"].ToString();
				partners1.AddressPartner = ds.Tables[0].Rows[i]["addressPartner"].ToString();
				partners1.TypePartnerName = ds.Tables[0].Rows[i]["typePartnerName"].ToString();
				partners1.Inn = float.Parse(ds.Tables[0].Rows[i]["inn"].ToString());
				partners1.Rating = int.Parse(ds.Tables[0].Rows[i]["rating"].ToString());
				partners1.TypePartnerId = int.Parse(ds.Tables[0].Rows[i]["typePartnerId"].ToString());
				partners.Add(partners1);
			}
			return partners;
		}


		public int GetSales(int partnersId)
		{
			string sqlSale = $"select sum(countProd) as sumCount from Purchase where partnersId = {partnersId}";
			int sale = 0;
			DataSet ds = classAdo.GetDataSet(sqlSale);
			int sumCount = int.Parse(ds.Tables[0].Rows[0]["sumCount"].ToString());
			if (sumCount < 10000)
			{
				sale = 0;
			}
			if (sumCount >= 10000 && sumCount < 50000)
			{
				sale = 5;
			}
			if (sumCount >= 50000 && sumCount < 300000)
			{
				sale = 10;
			}
			if (sumCount >= 300000)
			{
				sale = 15;
			}
			return sale;
		}

	}
}

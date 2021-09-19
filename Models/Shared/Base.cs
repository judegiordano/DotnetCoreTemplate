using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Services.Utility;

namespace WebApiTemplate.Models.Shared
{
	[Index(nameof(Uid), IsUnique = true)]
	public class Base
	{
		public Base()
		{
			Uid = Utility.GenerateGuid();
			DateCreated = DateTime.Now;
		}

		[Key]
		[IgnoreDataMember]
		public int Id { get; set; }

		[Required]
		public Guid Uid { get; private set; }

		[Required]
		[IgnoreDataMember]
		[DataType(DataType.DateTime)]
		public DateTime DateCreated { get; private set; }

		[IgnoreDataMember]
		public bool IsDeleted { get; set; } = false;
	}
}
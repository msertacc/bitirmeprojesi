﻿namespace Entity.Domain.BaseEntity
{
	public class BaseEntity
    {
        public int Id { get; set; }
        public string InsertedUser { get; set; }

        public DateTime InsertedDate { get; set; }

        public string? UpdatedUser { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string IsActive { get; set; }
    }
}

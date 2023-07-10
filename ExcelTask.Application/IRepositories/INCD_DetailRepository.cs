﻿using ExcelTask.Core.Entities;

namespace ExcelTask.Application.IRepositories;

public interface INCD_DetailRepository : IGenericRepository<NCD_Detail>
{
    Task<IEnumerable<NCD_Detail>> GetEntitiesByPatientIdAsync(int patientId);
}

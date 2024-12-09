namespace ApiaryManagementSystem.Application.Features.Diseases.Queries;
public sealed record DiseaseModel(
    Guid Id,
    string Name,
    string Treatment,
    string? Description,
    Guid HiveId);

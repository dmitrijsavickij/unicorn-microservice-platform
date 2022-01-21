﻿namespace Unicorn.Core.Development.ServiceHost.SDK.DTOs;

public record FilmDescriptionDTO
{
    public Guid DescriptionId { get; set; }
    public Guid FilmId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateOnly ReleaseDate { get; set; }
}

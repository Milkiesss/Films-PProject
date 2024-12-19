﻿using System.Text.Json.Serialization;

namespace Films_PProject.Application.Dtos.UserDto.UserMovies;

public class CreateUserMovieRequest
{
    [JsonIgnore]
    public Guid UserId { get; set; }
    public Guid MovieId { get; set; }
}
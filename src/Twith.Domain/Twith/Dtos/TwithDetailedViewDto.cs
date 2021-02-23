﻿using System;

namespace Twith.Domain.Twith.Dtos
{
    public record TwithDetailedViewDto : TwithListViewDto
    {
        public TwithDetailedViewDto(
            Guid id,
            string content,
            DateTime createdAt,
            AuthorDto author,
            int likesCount,
            bool liked
        ) : base(id, content, createdAt, author, likesCount, liked)
        {
        }
    }
}
﻿using AutoMapper;
using Mahta.Extensions.ObjectMappers.Abstractions;
using Microsoft.Extensions.Logging;

namespace Mahta.Extensions.ObjectMappers.AutoMapper.Services;


public class AutoMapperAdapter : IMapperAdapter
{
    private readonly IMapper _mapper;
    private readonly ILogger<AutoMapperAdapter> _logger;

    #region Constructor
    public AutoMapperAdapter(IMapper mapper, ILogger<AutoMapperAdapter> logger)
    {
        _mapper = mapper;
        _logger = logger;
        _logger.LogInformation("AutoMapper Adapter Start working");
    }


    #endregion

    #region Methods
    public TDestination Map<TSource, TDestination>(TSource source)
    {
        _logger.LogTrace("AutoMapper Adapter Map {source} To {destination} with data {sourcedata}",
                         typeof(TSource),
                         typeof(TDestination),
                         source);

        return _mapper.Map<TDestination>(source);
    } 
    #endregion
}
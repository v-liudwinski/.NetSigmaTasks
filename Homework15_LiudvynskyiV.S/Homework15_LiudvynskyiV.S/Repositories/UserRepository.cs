﻿using AutoMapper;
using Homework15_LiudvynskyiV.S.Data;
using Homework15_LiudvynskyiV.S.Models.Domain;
using Homework15_LiudvynskyiV.S.Models.ViewModels;
using Homework15_LiudvynskyiV.S.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Homework15_LiudvynskyiV.S.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CinemaNetworkDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserRepository(CinemaNetworkDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<UserViewModel>> GetAll()
    {
        var users = await _dbContext.Users.ToListAsync();
        return _mapper.Map<List<UserViewModel>>(users);
    }

    public async Task<UserViewModel?> Get(Guid id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        return user is null ? default : _mapper.Map<UserViewModel>(user);
    }

    public async Task<UserViewModel?> Add(UserViewModel userViewModel)
    {
        if (userViewModel is null) return default;
        var user = _mapper.Map<User>(userViewModel);
        user.Id = new Guid();
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return userViewModel;
    }

    public async Task<UserViewModel?> Update(Guid id, UserViewModel userViewModel)
    {
        if (userViewModel is null) return default;
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user is null) return default;
        _mapper.Map<Ticket>(userViewModel);
        await _dbContext.SaveChangesAsync();
        return userViewModel;
    }

    public async Task<UserViewModel?> Delete(Guid id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user is null) return default;
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<UserViewModel>(user);
    }
}
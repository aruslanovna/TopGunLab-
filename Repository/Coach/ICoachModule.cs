﻿using Domain;

namespace Repository
{
    public interface ICoachModule
    {
        void plusForTeam(Coach coach);
        Coach GetCoachById(int coach);
    }
}
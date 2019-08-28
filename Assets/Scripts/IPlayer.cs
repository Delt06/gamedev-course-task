using System;

public interface IPlayer
{
    InputData InputData { get; set; }

    event EventHandler Moving;
    event EventHandler Idling;
    event EventHandler Death;
    event EventHandler Fall;
    
    float MoveSpeed { get; }
    bool Alive { get; set; }
}
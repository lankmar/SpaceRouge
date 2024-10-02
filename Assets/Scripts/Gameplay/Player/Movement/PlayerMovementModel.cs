using Scriptables.Modules;
using UnityEngine;


namespace Gameplay.Player.Movement
{
    public sealed class PlayerMovementModel
    {
        private readonly EngineModuleConfig _config;
        public float MaxSpeed => _config.maximumSpeed;
        public float StoppingSpeed => _config.stoppingSpeed;

        public float CurrentSpeed { get; private set; }
        public float CurrentTurnRate { get; private set; }
        
        
        private float TurnSpeedDifference => _config.maximumTurnSpeed - _config.startingTurnSpeed;
        public PlayerMovementModel(EngineModuleConfig config)
        {
            _config = config;
            CurrentSpeed = 0.0f;
            CurrentTurnRate = 0.0f;
        }

        public void Accelerate(bool movingForward)
        {
            float acceleration = CountAcceleration(_config.maximumSpeed, _config.accelerationTime);
            acceleration *= movingForward ? 1 : -1;
            float maxSpeed = movingForward ? _config.maximumSpeed : -1 * _config.maximumBackwardSpeed;

            switch (movingForward)
            {
                case true when Mathf.Abs(CurrentSpeed) < Mathf.Abs(maxSpeed):
                case false when CurrentSpeed > maxSpeed:
                    CurrentSpeed += acceleration;
                    return;
                case true when Mathf.Abs(CurrentSpeed) > Mathf.Abs(maxSpeed):
                case false when CurrentSpeed < maxSpeed:
                    CurrentSpeed = maxSpeed;
                    break;
            }
        }

        public void Turn(bool turningLeft)
        {
            bool isContinuingTurn = CurrentTurnRate < 0 == turningLeft;

            if (!isContinuingTurn || CurrentTurnRate == 0)
            {
                float startingTurnSpeed = turningLeft ? -1 * _config.startingTurnSpeed : _config.startingTurnSpeed;
                CurrentTurnRate = startingTurnSpeed;
                return;
            }
            
            float turnAcceleration = CountAcceleration(TurnSpeedDifference, _config.turnAccelerationTime);

            if (Mathf.Abs(CurrentTurnRate) > _config.maximumTurnSpeed)
            {
                CurrentTurnRate = turningLeft ? -1 * _config.maximumTurnSpeed : _config.maximumTurnSpeed;
            }
            
            if (Mathf.Abs(CurrentTurnRate) < _config.maximumTurnSpeed)
            {
                float signedAcceleration = turningLeft ? -1 * turnAcceleration : turnAcceleration;
                CurrentTurnRate += signedAcceleration;
                return;
            }
            
            if (Mathf.Abs(CurrentTurnRate) > _config.maximumTurnSpeed)
            {
                CurrentTurnRate = turningLeft ? -1 * _config.maximumTurnSpeed : _config.maximumTurnSpeed;
            }
        }
        
        public void StopTurning() => CurrentTurnRate = 0.0f;
        public void StopMoving() => CurrentSpeed = 0.0f;

        private static float CountAcceleration(float speedDifference, float accelerationTime)
        {
            float deltaTime = Time.deltaTime;
            if (accelerationTime <= 0) return speedDifference * deltaTime * 10; //Prevents zero division
            return speedDifference * deltaTime / accelerationTime;
        }
    }
}
// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;
using System.Security.Cryptography;

// The namespace your code is in.
namespace Game10003
{
    
    public class Game
    {
        // Player
        Vector2 playerPosition = new Vector2(450, 400);
        Vector2 playerVelocity = new Vector2(0, 0);
        int playerSize = 10;
        float playerGravity = 0.1f;
        float playerSpeed = 2.5f;
        float playerJumpSpeed = 3f;

        // Platforms
        Vector2 platformSize = new Vector2(50, 10);
        Vector2[] platformPositions = { 
            new Vector2(450, 450),
            new Vector2(450, 200),
        };
        
        public void Setup()
        {
            Window.SetSize(600, 800);
            Window.TargetFPS = 60;

            
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            DrawPlatforms();
            HandlePlayer();
        }

        void HandlePlayer()
        {
            HandleInput();

            // Platform collision detection
            for (int i = 0; i < platformPositions.Length; i++)
            {
                if (playerPosition.X >= platformPositions[i].X &&
                    playerPosition.X <= platformPositions[i].X + platformPositions[i].X &&
                    playerPosition.Y <= platformPositions[i].Y &&
                    playerPosition.Y + playerSize >= platformPositions[i].Y)
                {
                    playerVelocity = new Vector2(playerVelocity.X, 0);
                    playerPosition = new Vector2(playerPosition.X, platformPositions[i].Y - playerSize);
                }
                else
                {
                    playerVelocity = new Vector2(playerVelocity.X, playerVelocity.Y + playerGravity);
                }
            }

            // Update position based on velocity
            playerPosition = playerPosition + playerVelocity;

            // Draw player at position
            Draw.FillColor = Color.Blue;
            Draw.Circle(playerPosition, playerSize);
        }


        void HandleInput()
        {
            // Jump Input
            if (Input.IsKeyboardKeyPressed(KeyboardInput.W))
            {
                playerVelocity = new Vector2(playerVelocity.X, -playerJumpSpeed);
            }
            else
            {
                playerVelocity = new Vector2(0, playerVelocity.Y);
            }

            // Left Input
            if (Input.IsKeyboardKeyPressed(KeyboardInput.A))
            {
                playerVelocity = new Vector2(-playerSpeed, playerVelocity.Y);
            }
            else
            {
                playerVelocity = new Vector2(0, playerVelocity.Y);
            }

            // Right Input
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                playerVelocity = new Vector2(playerSpeed, playerVelocity.Y);
            }
        }


        void DrawPlatforms()
        {
            Draw.FillColor = Color.Red;
            
            for (int i = 0; i < platformPositions.Length; i++)
            {
                Draw.Rectangle(platformPositions[i], platformSize);
            }
        }
    }
}

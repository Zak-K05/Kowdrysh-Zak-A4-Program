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
        Vector2 playerSize = new Vector2(10, 10);
        Vector2 playerPosition = new Vector2(450, 400);

        // Platforms
        Vector2 platformSize = new Vector2(50, 10);
        Vector2[] platformPositions = { 
            new Vector2(450, 450)
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
            DrawPlayer();
        }

        void DrawPlayer()
        {
            Draw.FillColor = Color.Blue;
            Draw.Rectangle(playerPosition, playerSize);
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

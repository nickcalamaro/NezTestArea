using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Textures;


namespace NezExample
{
    /// <summary>
    /// A helper class representing a region on a texture.
    /// </summary>
    public class Subtexture
    {
        public Texture2D Texture { get; }
        public Rectangle SourceRect { get; }
        public Vector2 Origin { get; }

        public Subtexture(Texture2D texture, Rectangle sourceRect)
        {
            Texture = texture;
            SourceRect = sourceRect;
            // Sets the origin to the center of the frame.
            Origin = new Vector2(sourceRect.Width / 2f, sourceRect.Height / 2f);
        }
    }

    /// <summary>
    /// The main game scene that sets up animations for up, right, and down movement.
    /// </summary>
    public class Game1 : Nez.Core
    {
        protected override void Initialize()
        {
            base.Initialize();

            // Create the scene using the default renderer.
            var scene = Scene.CreateWithDefaultRenderer(Color.AliceBlue);

            // Load the sprite atlas. Make sure Nez.Content.Eevee_walk_sprites is defined in your Content project.
            Texture2D atlasTexture = scene.Content.LoadTexture(Nez.Content.Eevee_walk_sprites);

            // Define the frames for each animation as Subtexture arrays.
            Subtexture[] walkDownFrames = new Subtexture[]
            {
                new Subtexture(atlasTexture, new Rectangle(0, 0, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(40, 0, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(80, 0, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(120, 0, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(160, 0, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(200, 0, 40, 40))
            };

             Subtexture[] walkDownRightFrames = new Subtexture[]
            {
                new Subtexture(atlasTexture, new Rectangle(0, 48, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(40, 48, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(80, 48, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(120, 48, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(160, 48, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(200, 48, 40, 40))
            };

            // WalkRight frames: starting at (0, 96, 32, 32)
            Subtexture[] walkRightFrames = new Subtexture[]
            {
                new Subtexture(atlasTexture, new Rectangle(0, 96, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(40, 96, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(80, 96, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(120, 96, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(160, 96, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(200, 96, 40, 40))
            };

            // WalkRight frames: starting at (0, 96, 32, 32)
            Subtexture[] walkUpRightFrames = new Subtexture[]
            {
                new Subtexture(atlasTexture, new Rectangle(0, 144, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(40, 144, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(80, 144, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(120, 144, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(160, 144, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(200, 144, 40, 40))
            };

            // WalkUp frames: starting at (0, 192, 32, 32)
            Subtexture[] walkUpFrames = new Subtexture[]
            {
                new Subtexture(atlasTexture, new Rectangle(0, 192, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(40, 192, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(80, 192, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(120, 192, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(160, 192, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(200, 192, 40, 40))
            };


            // WalkUpLeft frames: starting at (0, 192, 32, 32)
            Subtexture[] walkUpLeftFrames = new Subtexture[]
            {
                new Subtexture(atlasTexture, new Rectangle(0, 240, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(40, 240, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(80, 240, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(120, 240, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(160, 240, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(200, 240, 40, 40))
            };


            Subtexture[] walkLeftFrames = new Subtexture[]
            {
                new Subtexture(atlasTexture, new Rectangle(0, 288, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(40, 288, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(80, 288, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(120, 288, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(160, 288, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(200, 288, 40, 40))
            };


            // WalkDownLeft frames: starting at (0, 192, 32, 32)
            Subtexture[] walkDownLeftFrames = new Subtexture[]
            {
                new Subtexture(atlasTexture, new Rectangle(0, 336, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(40, 336, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(80, 336, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(120, 336, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(160, 336, 40, 40)),
                new Subtexture(atlasTexture, new Rectangle(200, 336, 40, 40))
            };

            // Convert each Subtexture array into a Sprite array since SpriteAnimator.AddAnimation expects Sprites.
            Sprite[] walkDownSprites = ConvertSubtexturesToSprites(walkDownFrames);
            Sprite[] walkRightSprites = ConvertSubtexturesToSprites(walkRightFrames);
            Sprite[] walkUpSprites = ConvertSubtexturesToSprites(walkUpFrames);
            Sprite[] walkLeftSprites = ConvertSubtexturesToSprites(walkLeftFrames);
            Sprite[] walkDownLeftSprites = ConvertSubtexturesToSprites(walkDownLeftFrames);
            Sprite[] walkDownRightSprites = ConvertSubtexturesToSprites(walkDownRightFrames);
            Sprite[] walkUpLeftSprites = ConvertSubtexturesToSprites(walkUpLeftFrames);
            Sprite[] walkUpRightSprites = ConvertSubtexturesToSprites(walkUpRightFrames);
            
            

            // Create an entity for your character.
            Entity eeveeEntity = scene.CreateEntity("eevee");

            // Create a default sprite using one of the frames (using walkDown's first frame here).
            Sprite defaultSprite = new Sprite(walkDownFrames[0].Texture, walkDownFrames[0].SourceRect, walkDownFrames[0].Origin);

            // Add a SpriteAnimator component to the entity; SpriteAnimator derives from SpriteRenderer.
            SpriteAnimator animator = eeveeEntity.AddComponent(new SpriteAnimator(defaultSprite));

            // Add animations with a desired frame rate (10 frames per second here).
            animator.AddAnimation("walkDown", walkDownSprites, 10f);
            animator.AddAnimation("walkRight", walkRightSprites, 10f);
            animator.AddAnimation("walkUp", walkUpSprites, 10f);
            animator.AddAnimation("walkLeft", walkLeftSprites, 10f);
            animator.AddAnimation("walkDownLeft", walkDownLeftSprites, 10f);
            animator.AddAnimation("walkDownRight", walkDownRightSprites, 10f);
            animator.AddAnimation("walkUpLeft", walkUpLeftSprites, 10f);
            animator.AddAnimation("walkUpRight", walkUpRightSprites, 10f);

            // Optionally start with an initial animation.
            animator.Play("walkDown");

            // Scale the entity for better visibility (e.g. scaling by 4 makes 32×32 become 128×128).
            eeveeEntity.Transform.Scale = new Vector2(4f, 4f);

            // Center the entity on the screen.
            eeveeEntity.Transform.Position = new Vector2(Screen.Width / 2, Screen.Height / 2);

            // Add a movement component that will update both position and animation based on input.
            eeveeEntity.AddComponent(new PlayerMovement(animator));

            // Set this scene as the active scene.
            Core.Scene = scene;
        }

        /// <summary>
        /// Helper method to convert an array of Subtexture objects into an array of Sprites.
        /// </summary>
        private Sprite[] ConvertSubtexturesToSprites(Subtexture[] subtextures)
        {
            Sprite[] sprites = new Sprite[subtextures.Length];
            for (int i = 0; i < subtextures.Length; i++)
            {
                sprites[i] = new Sprite(
                    subtextures[i].Texture,
                    subtextures[i].SourceRect,
                    subtextures[i].Origin
                );
            }
            return sprites;
        }
    }

    /// <summary>
    /// A component that moves the entity based on keyboard input and
    /// plays the appropriate animation for the movement direction.
    /// </summary>
    public class PlayerMovement : Component, IUpdatable
{
    // Movement speed in pixels per second.
    public float Speed = 200f;
    private SpriteAnimator _animator;

    private bool _pendingStop = false;

    private float animationSwitchDelay = 0.1f; // delay in seconds
    private float animationSwitchTimer = 0f;
    private string lastAnimation = ""; // store last played animation
    private Vector2 _lastMoveDirection = Vector2.Zero;


    public PlayerMovement(SpriteAnimator animator)
    {
        _animator = animator;
    _animator.OnAnimationCompletedEvent += OnAnimationCompleted;    
    }

    // This callback fires when an animation playing in Once mode finishes.
    private void OnAnimationCompleted(string animationName)
    {
        if (_pendingStop)
        {
            // Stop the animator...
            _animator.Stop();
            // Then add the final offset of 2 pixels in the last move direction.
            if (_lastMoveDirection != Vector2.Zero)
            {
                // Make sure the direction is normalized before scaling.
                _lastMoveDirection.Normalize();
                Entity.Transform.Position += _lastMoveDirection * 10f;
            }
            _pendingStop = false;
        }
    }

    public void Update()
    {
        // Build the movement vector based on keyboard input.
        Vector2 movement = Vector2.Zero;
        if (Input.IsKeyDown(Keys.W) || Input.IsKeyDown(Keys.Up))
            movement.Y -= 1;
        if (Input.IsKeyDown(Keys.S) || Input.IsKeyDown(Keys.Down))
            movement.Y += 1;
        if (Input.IsKeyDown(Keys.A) || Input.IsKeyDown(Keys.Left))
            movement.X -= 1;
        if (Input.IsKeyDown(Keys.D) || Input.IsKeyDown(Keys.Right))
            movement.X += 1;



       if (movement != Vector2.Zero)
        {
            movement.Normalize();
            // Update the last move direction to be used for the final offset.
            _lastMoveDirection = movement;
            // Move the entity based on input.
            Entity.Transform.Position += movement * Speed * Time.DeltaTime;

            // If new movement input arrives while we’re finishing a cycle,
            // cancel the pending stop and restore looping.
            if (_pendingStop)
            {
                _pendingStop = false;
                _animator.SetLoopMode(SpriteAnimator.LoopMode.Loop);
            }

            // Determine which animation to play based on input.
            string desiredAnimation = GetAnimationNameFromMovement(movement);


            if (IsDiagonal(lastAnimation) && !IsDiagonal(desiredAnimation))
            {
                animationSwitchTimer += Time.DeltaTime;
                if (animationSwitchTimer < animationSwitchDelay)
                {
                    // Keep playing the last diagonal animation.
                    desiredAnimation = lastAnimation;
                }
                else
                {
                    // Delay expired: switch normally.
                    animationSwitchTimer = 0f;
                    lastAnimation = desiredAnimation;
                }
            }
            else
            {
                // If the new animation is diagonal, update our record and reset timer.
                if (IsDiagonal(desiredAnimation))
                {
                    lastAnimation = desiredAnimation;
                    animationSwitchTimer = 0f;
                }
                else
                {
                    // When switching between orthogonal animations, just update everything.
                    lastAnimation = desiredAnimation;
                    animationSwitchTimer = 0f;
                }
            }

            // Only update the animator if needed.
            if (_animator.CurrentAnimationName != desiredAnimation)
            {
                _animator.Play(desiredAnimation, SpriteAnimator.LoopMode.Loop);
            }
        }
        else
        {
            // No input: if an animation is running, set it to finish its current cycle.
            if (!_pendingStop && _animator.AnimationState == SpriteAnimator.State.Running)
            {
                _pendingStop = true;
                _animator.SetLoopMode(SpriteAnimator.LoopMode.Once);
            }
        }
    }

    // Helper method to choose an animation name based on movement direction.
    private string GetAnimationNameFromMovement(Vector2 movement)
    {
        if (Math.Abs(movement.X) == Math.Abs(movement.Y))
        {
            if (movement.X < 0)
                return movement.Y < 0 ? "walkUpLeft" : "walkDownLeft";
            else
                return movement.Y < 0 ? "walkUpRight" : "walkDownRight";
        }
        else if (Math.Abs(movement.X) > Math.Abs(movement.Y))
        {
            return movement.X < 0 ? "walkLeft" : "walkRight";
        }
        else
        {
            return movement.Y < 0 ? "walkUp" : "walkDown";
        }
    }


    private bool IsDiagonal(string animationName)
    {
        return animationName == "walkUpLeft" ||
               animationName == "walkUpRight" ||
               animationName == "walkDownLeft" ||
               animationName == "walkDownRight";
    }
}



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Engine
    {
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<GameObject> staticObjects;
        Racket playerRacket;
        int SleepTime { get; set; }

        //Constructor wich takes sleepTime as a new parameter
        public Engine(IRenderer renderer, IUserInterface userInterface, int sleepTime)
            : this(renderer, userInterface)
        {
            this.SleepTime = sleepTime;
        }

        public Engine(IRenderer renderer, IUserInterface userInterface)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
        }

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                if (obj is Racket)
                {
                    AddRacket(obj);

                }
                else
                {
                    this.AddStaticObject(obj);
                }
            }
        }

        private void AddRacket(GameObject obj)
        {
            //Task 3
            //TODO: we should remove the previous racket from this.allObjects
            foreach (var item in this.allObjects)
            {
                if (item is Racket)
                {
                    this.staticObjects.Remove(item);
                    this.allObjects.Remove(item);
                    break;
                }
            }

            this.playerRacket = obj as Racket;
            this.AddStaticObject(obj);
        }

        // task 4 - new method - used with shooting Racket
        public void ShootPlayerRacket()
        {
            this.playerRacket.shoot = true;
        }

        public virtual void MovePlayerRacketLeft()
        {
            this.playerRacket.MoveLeft();
        }

        public virtual void MovePlayerRacketRight()
        {
            this.playerRacket.MoveRight();
        }

        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(this.SleepTime);

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }

                bool AllBlocksDestroied = true;
                foreach (var item in staticObjects)
                {
                    if (item is UnpassableBlock || item is IndestructibleBlock || item is Racket || item is TrailObject)
                    {
                    }
                    else
                    {
                        AllBlocksDestroied = false;
                        break;
                    }
                }
                if (AllBlocksDestroied)
                {
                    Console.SetCursorPosition(3, 31);
                Console.WriteLine("Level completed!!");
                return;
                }
                
            }
        }
    }
}

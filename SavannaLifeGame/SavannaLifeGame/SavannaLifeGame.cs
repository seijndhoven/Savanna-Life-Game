using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Security;
using System.Windows.Forms;
using SavannaLifeGame.Data;
using SavannaLifeGame.Source;

namespace SavannaLifeGame
{
    public partial class SavannaLifeGame : Form
    {
        private readonly GameWorld gameWorld;
        private readonly Timer gameTimer;
        private readonly Random random;
        private Entity selectedEntity;
        private bool isRunning;

        public SavannaLifeGame()
        {
            InitializeComponent();

            gameWorld = new GameWorld();

            entitiesComboBox.SelectedIndex = 0;
            addEntityCheckBox.Checked = false;

            randomEntitySpawnComboBox.SelectedIndex = 0;
            spawnEntitiesRandomlyCheckBox.Checked = false;
            spawnRateTrackBar.Minimum = 1;
            spawnRateTrackBar.Maximum = 100;
            spawnRateTrackBar.TickFrequency = 10;

            saveFileDialog.Filter = ".dat file (*.dat)|*.dat";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            openFileDialog.Filter = ".dat file (*.dat)|*.dat";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            gameTimer = new Timer();
            SetupTimer(gameTimer);

            random = new Random();
            selectedEntity = null;
            isRunning = false;
        }

        private void SetupTimer(Timer timer)
        {
            const int framesPerSecond = 20;
            const int interval = 1000 / framesPerSecond;
            timer.Interval = interval;
            timer.Tick += gameTimer_Tick;
            timer.Start();
        }

        private void AddEntityToWorld(EntityTypes entityType, Point position)
        {
            Entity entity = null;

            switch (entityType)
            {
                case EntityTypes.Grass:
                    entity = new Grass(position);
                    break;
                case EntityTypes.Gazelle:
                    entity = new Gazelle(position);
                    break;
                case EntityTypes.Leopard:
                    entity = new Leopard(position);
                    break;
                case EntityTypes.Hippopotamus:
                    entity = new Hippopotamus(position);
                    break;
            }

            if (entity != null)
            {
                gameWorld.Add(entity);
            }
        }

        private void SpawnEntitiesRandomly()
        {
            if (spawnEntitiesRandomlyCheckBox.Checked)
            {
                int randomSpawnChance = random.Next(1, 101 / spawnRateTrackBar.Value);

                if (randomSpawnChance == 1)
                {
                    int randomX = random.Next(savannaPictureBox.Width);
                    int randomY = random.Next(savannaPictureBox.Height);

                    Point position = new Point(randomX, randomY);

                    AddEntityToWorld((EntityTypes)randomEntitySpawnComboBox.SelectedIndex, position);
                }
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (isRunning && gameWorld.Entities.Count > 0)
            {
                gameWorld.RunOneTurn();
            }
            else
            {
                isRunning = false;
                playPauseButton.Text = "Play";
            }

            SpawnEntitiesRandomly();

            savannaPictureBox.Refresh();
        }

        private void savannaPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            foreach (Entity entity in gameWorld.Entities)
            {
                entity.DrawTo(canvas);
            }

            if (gameWorld.Entities.Contains(selectedEntity))
            {
                entityInfoTextBox.Text = selectedEntity.ToString();
                canvas.DrawRectangle(Pens.Crimson, selectedEntity.Position.X - 1, selectedEntity.Position.Y - 1, selectedEntity.BoundingBox.Width + 2, selectedEntity.BoundingBox.Height + 2);
                canvas.DrawRectangle(Pens.Crimson, selectedEntity.Position.X - 2, selectedEntity.Position.Y - 2, selectedEntity.BoundingBox.Width + 4, selectedEntity.BoundingBox.Height + 4);
                canvas.DrawRectangle(Pens.Red, selectedEntity.Position.X - 3, selectedEntity.Position.Y - 3, selectedEntity.BoundingBox.Width + 6, selectedEntity.BoundingBox.Height + 6);
            }
            else
            {
                selectedEntity = null;
                entityInfoTextBox.Text = String.Empty;
            }
        }

        private void playPauseButton_Click(object sender, EventArgs e)
        {
            if (gameWorld.Entities.Count < 1)
            {
                MessageBox.Show("There are no entities.");
            }
            else
            {
                isRunning = !isRunning;

                const string pauseString = "Pause";
                const string playString = "Play";

                switch (isRunning)
                {
                    case true:
                        playPauseButton.Text = pauseString;
                        break;
                    case false:
                        playPauseButton.Text = playString;
                        break;
                }
            }
        }

        private void savannaPictureBox_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs mouseEvent)
            {
                Point position = mouseEvent.Location;

                if (addEntityCheckBox.Checked)
                {
                    AddEntityToWorld((EntityTypes)entitiesComboBox.SelectedIndex, position);
                }
                else
                {
                    selectedEntity = gameWorld.Find(position);
                }
            }
        }

        private void removeEntityButton_Click(object sender, EventArgs e)
        {
            if (selectedEntity == null || !gameWorld.Entities.Contains(selectedEntity))
            {
                MessageBox.Show("There is no entity selected to remove, or there are no entities.");
            }
            else
            {
                gameWorld.Remove(selectedEntity);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (gameWorld.Entities.Count == 0)
            {
                MessageBox.Show("There are no entities to clear.");
            }
            else
            {
                gameWorld.Entities.Clear();
                isRunning = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                gameWorld.Save(saveFileDialog.FileName);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (SerializationException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (SecurityException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (PathTooLongException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (DirectoryNotFoundException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                gameWorld.Load(openFileDialog.FileName);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (SerializationException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (SecurityException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (PathTooLongException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (DirectoryNotFoundException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
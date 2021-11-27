using Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCube.Structures
{
    public class RubiksCube
    {
        public int Id { get; set; }

        public Dictionary<string, char> Faces = new Dictionary<string, char>();

        public Dictionary<Color, AxisOfRotation> AxesOfRotation = new Dictionary<Color, AxisOfRotation>();

        public char this[string faceId] 
        { 
            get 
            {
                return Faces[faceId];
            } 
            set 
            {
                Faces[faceId] = value;
            }
        }

        public RubiksCube()
        {
            for(var i = 0; i < 6; i++)
            {
                var color = (Color)i;
                var firstChar = char.ToUpper(color.ToString()[0]);

                for(var j = 0; j < 9; j++)
                {
                    Faces.Add($"{firstChar}{j}", firstChar);
                }
            }

            var builder = new AxisOfRotation();
            var axes = builder.Create();

            axes.ForEach(x =>
            {
                AxesOfRotation.Add(x.Color, x);
            });
        }

        private void CreateAxisOfRotation(Color color)
        {            
            for (var i = 0; i < 9; i++)
            {
                var firstChar = char.ToUpper(color.ToString()[0]);

                Faces.Add($"{firstChar}{i}", firstChar);
            }

        }

        public void RotateOnAxis(Color color, bool isClockwise)
        {
            if (isClockwise)
                Clockwise(color);
            else
                CounterClockwise(color);
        }

        #region private members

        private void Clockwise(Color color)
        {
            var axis = AxesOfRotation[color];

            RotateFaces(axis, true);

            var upper = axis.Upper;
            var right = axis.Right;
            var lower = axis.Lower;
            var left = axis.Left;

            var buffer = GetFaceColors(upper);

            CopyColors(left, upper);
            CopyColors(lower, left);
            CopyColors(right, lower);
            CopyColors(buffer, right);
        }

        private void CounterClockwise(Color color)
        {
            var axis = AxesOfRotation[color];

            RotateFaces(axis, false);

            var upper = axis.Upper;
            var right = axis.Right;
            var lower = axis.Lower;
            var left = axis.Left;

            var buffer = GetFaceColors(upper);

            CopyColors(right, upper);
            CopyColors(lower, right);
            CopyColors(left, lower);
            CopyColors(buffer, left);
        }

        private void RotateFaces(AxisOfRotation axis, bool isClockwise)
        {
            var faceIds = axis.Front.Where(x => !x.EndsWith("0")).ToList();

            var newRotation = isClockwise ?
                 new char[8]
                {
                    Faces[faceIds[6]],
                    Faces[faceIds[7]],
                    Faces[faceIds[0]],
                    Faces[faceIds[1]],
                    Faces[faceIds[2]],
                    Faces[faceIds[3]],
                    Faces[faceIds[4]],
                    Faces[faceIds[5]]                    
                }
                : new char[8]
                {
                    Faces[faceIds[2]],
                    Faces[faceIds[3]],
                    Faces[faceIds[4]],
                    Faces[faceIds[5]],
                    Faces[faceIds[6]],
                    Faces[faceIds[7]],
                    Faces[faceIds[0]],
                    Faces[faceIds[1]]
                };

            for(var i = 0; i < faceIds.Count; i++)
            {
                Faces[faceIds[i]] = newRotation[i];
            }
        }

        private char[] GetFaceColors(string[] ids)
        {
            var colors = new char[ids.Length];

            for (var i = 0; i < ids.Length; i++) 
            {
                colors[i] = Faces[ids[i]];
            }

            return colors;
        }

        private void CopyColors(string[] fromIds, string[] toIds)
        {
            for(var i = 0; i < fromIds.Length; i++)
            {
                Faces[toIds[i]] = Faces[fromIds[i]];
            }
        }

        private void CopyColors(char[] from, string[] toIds)
        {
            for(var i = 0; i < from.Length; i++)
            {
                Faces[toIds[i]] = from[i];
            }
        }

        #endregion

    }
}

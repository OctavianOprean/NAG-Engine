#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.IO;
#endregion

namespace NAGEngine.System
{
    public enum ResourceType
    {
        texture2DList
    }
    public static class ResourceLoader
    {
        private static GraphicsDeviceManager currentDevice;
        private static FileStream stream;
        private static Texture2D tempText;
        private static List<Texture2D> tempTList;
        private static Dictionary<string, List<Texture2D>> TextureAssets;
        private static List<Tuple<string, string>> TextureLinks;

        static ResourceLoader()
        {
            currentDevice = null;
            stream = null;
            tempText = null;
            tempTList = null;
            TextureAssets = new Dictionary<string, List<Texture2D>>();
            TextureLinks = new List<Tuple<string, string>>();
        }

        public static void AssignGraphicsDevice(GraphicsDeviceManager device)
        {
            currentDevice = device;
        }

        public static void LoadReguest(ResourceType Type, string handler, string[] path)
        {
            switch (Type)
            {
                case ResourceType.texture2DList:
                    {
                        tempTList = new List<Texture2D>();
                        foreach (string a in path)
                        {
                            tempTList.Add(LoadTexture(a));
                        }

                        TextureAssets.Add(handler, tempTList);
                        tempTList = null;
                        break;
                    }
            }

        }

        public static string LoadReguest(ResourceType Type,string[] path)
        {
            string handler =  Guid.NewGuid().ToString();
            switch (Type)
            {
                case ResourceType.texture2DList:
                    {
                        tempTList = new List<Texture2D>();
                        foreach (string a in path)
                        {
                            tempTList.Add(LoadTexture(a));
                        }

                        TextureAssets.Add(handler, tempTList);
                        tempTList = null;
                        break;
                    }
            }
            return handler;
        }

        public static void Link(string AssetHandler, string EntityID)
        {
            TextureLinks.Add(new Tuple<string, string>(AssetHandler, EntityID));
        }

        private static Texture2D LoadTexture(string path)
        {
            stream = new FileStream(path,FileMode.Open);
            tempText = Texture2D.FromStream(currentDevice.GraphicsDevice, stream);
            stream.Close();
            return tempText;            
        }

        public static void InitializeXNAGraphicEntities(Dictionary<string,XNARenderable> GEntityList)
        {
            foreach (Tuple<string, string> link in TextureLinks)
            {
                GEntityList[link.Item2].LoadTexturList(TextureAssets[link.Item1].ToArray());
            }
            TextureLinks.Clear();
        }


    }
}

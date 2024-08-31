using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpecialScanner.Model
{
    public class BoardTools
    {
        public static byte[] DataToJson(Board board)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Board));
            ArraySegment<byte> data = null;


            using (var ms = new MemoryStream())
            {
                jsonFormatter.WriteObject(ms, board);
                ms.TryGetBuffer(out data);
            }
        
            return data.ToArray();
        }

        public static Board JsonToData(byte[] buffer)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Board));
            
            var board = new Board();

            using (var ms = new MemoryStream(buffer))
            {
                var deserializer = new DataContractJsonSerializer(typeof(Board));
                var result = (Board)deserializer.ReadObject(ms);
                board.BoardBrand = result.BoardBrand;
                board.АmountKnots = result.АmountKnots;
                
            }

            return board;
        }
    }
}

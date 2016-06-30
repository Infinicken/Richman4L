/*
* Richman4L: A free game with a rule like Richman4Fun.
* Copyright (C) 2010-2016 Wencey Wang
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Affero General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU Affero General Public License for more details.
*
* You should have received a copy of the GNU Affero General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System . Collections . Generic;
using System . Text;
using System . IO;
using System . Threading . Tasks;
using System . Threading;
using Windows . Storage;

namespace WenceyWang . Richman4L . App . Logic . Saving
{
    class SavingItem
    {
        public string Name { get; set; }

        public string Map { get; set; }

        public DateTime Date { get; set; }

        public StorageFile File { get; set; }

        public async void Delete ( )
        {
            await File . DeleteAsync ( );
        }

        public async static Task<List<SavingItem>> GetSaving ( )
        {
            List<SavingItem> list = new List<SavingItem> ( );

            IReadOnlyList < StorageFile > fileList = await ApplicationData . Current . RoamingFolder . GetFilesAsync ( Windows . Storage . Search . CommonFileQuery . OrderByDate );

            foreach ( StorageFile item in fileList )
            {
                if ( item . FileType == "r4lsav" )
                {
                    list . Add ( new SavingItem ( item ) );
                }
            }

            list . Sort ( );

            return list;
        }

        public SavingItem ( StorageFile file )
        {
            string [ ] fileName = file . Name . Split ( ( "_" ) . ToCharArray ( ) );

            Name = fileName [ 0 ];

            Map = fileName [ 1 ];

            Date = DateTime . Parse ( fileName [ 2 ] );

            File = file;
        }

    }
}

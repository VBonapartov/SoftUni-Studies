using System.Collections;
using System.Collections.Generic;

class RoomsRegister : IEnumerable<int>
{
    private readonly List<Pet> rooms;
    private readonly int centerRoomIndex = 0;

    public RoomsRegister(int roomsNumber)
    {
        this.centerRoomIndex = roomsNumber / 2;
        this.rooms = new List<Pet>(new Pet[roomsNumber]);
    }

    public Pet this[int index]
    {
        get => this.rooms[index];
        set => this.rooms[index] = value;
    }

    public IEnumerator<int> GetEnumerator()
    {
        int step = 1;

        yield return this.centerRoomIndex;

        while (step <= this.centerRoomIndex)
        {
            yield return this.centerRoomIndex - step;

            yield return this.centerRoomIndex + step++;
        }

        //for (int i = 0; i <= this.centerRoomIndex; i++)
        //{
        //    if (this.rooms[this.centerRoomIndex - i] == null)
        //    {
        //        yield return this.centerRoomIndex - i;
        //    }

        //    if (this.rooms[this.centerRoomIndex + i] == null)
        //    {
        //        yield return this.centerRoomIndex - i;
        //    }
        //}
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

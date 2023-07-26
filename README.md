# 401Lab: Async Hotel Chain
done by Patterson

```+---------------------+     +----------------+     +----------------------+
|   HotelLocation     |     |     Room       |     |       Amenity        |
+---------------------+     +----------------+     +----------------------+
| LocationId (PK)     |     | RoomId (PK)   |     | AmenityId (PK)       |
| Name                |     | Nickname      |     | Name                 |
| City                |     | LayoutType    |     +----------------------+
| State               |     | Price         |
| Address             |     | PetFriendly   |
| PhoneNumber         |     | LocationId (FK)|
+---------------------+     +----------------+
                             |
                             |
                         +------------------+
                         | RoomAmenity      |
                         +------------------+
                         | RoomId (FK)      |
                         | AmenityId (FK)   |
                         | Description      |
                         +------------------+
```

Entities:
1. HotelLocation:
   - Primary Key: LocationId
   - Attributes: Name, City, State, Address, PhoneNumber

2. Room:
   - Primary Key: RoomId
   - Attributes: Nickname, LayoutType, Price, PetFriendly
   - Foreign Key: LocationId (to associate the room with a specific hotel location)

3. Amenity:
   - Primary Key: AmenityId
   - Attributes: Name

4. RoomAmenity (Joint Entity Table with Payload):
   - Composite Primary Key: RoomId, AmenityId
   - Attributes: Description
   - Foreign Keys: RoomId (references Room table), AmenityId (references Amenity table)

Enumerations:
1. LayoutType:
   - Values: OneBedroom, TwoBedroom, Studio

Relationships:
- HotelLocation (1) to Room (Many): Each hotel location can have multiple rooms, but each room belongs to only one location.
- Room (Many) to Amenity (Many): Each room can have multiple amenities, and each amenity can be associated with multiple rooms. This is a many-to-many relationship, which is represented by the joint entity table "RoomAmenity."

Explanation:
1. HotelLocation:
   This table represents different locations of the Async Inn hotel chain. It includes attributes like Name, City, State, Address, and PhoneNumber to store the specific details of each hotel location.

2. Room:
   This table represents the individual rooms in each hotel location. It includes attributes like Nickname (for unique identification of each room layout), LayoutType (using the LayoutType enumeration to specify the type of room layout), Price (to store the room's price), and PetFriendly (a boolean value to indicate if the room allows pets). The LocationId attribute is used as a foreign key to associate each room with a specific hotel location.

3. Amenity:
   This table contains the list of amenities that the hotel rooms can offer. It has an attribute called "Name" to store the name of each amenity.

4. RoomAmenity (Joint Entity Table with Payload):
   This table serves as a joint entity table to establish a many-to-many relationship between Room and Amenity entities. It has a composite primary key (RoomId, AmenityId) to uniquely identify each record. The "Description" attribute is used to store any additional information about a particular amenity in a specific room.

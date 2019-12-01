class VehicleLocation {
  String id;
  String route;
  String distance;
  String date;
  String latitude;
  String longitude;
  VehicleLocation(
      {this.id,
      this.route,
      this.longitude,
      this.latitude,
      this.distance,
      this.date});

  factory VehicleLocation.fromJson(dynamic json) {
    return new VehicleLocation(
        id: json['id'],
        route: json['routeTag'],
        distance: '1',
        date: json['secsSinceReport'],
        latitude: json['lat'],
        longitude: json['lon']);
  }
}

class VehicleLocations {
  final List<VehicleLocation> vehicleLocations;

  VehicleLocations({this.vehicleLocations});

  factory VehicleLocations.fromJson(List<dynamic> parsedJson) {
    List<VehicleLocation> vehicleLocations = new List<VehicleLocation>();

    return new VehicleLocations(
      vehicleLocations: vehicleLocations,
    );
  }
}

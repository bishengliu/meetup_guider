import MapDataService from './mapdata-service';
import RSVPCity from '../types/rsvp-city';

describe('getColor', () => {
  test('it should return color name as expected', () => {
    const data = [
      { input: 10, output: 'color0' },
      { input: 20, output: 'color1' },
      { input: 30, output: 'color2' },
      { input: 40, output: 'color3' },
      { input: 50, output: 'color4' },
      { input: 60, output: 'color5' },
      { input: 70, output: 'color6' },
      { input: 80, output: 'color7' },
      { input: 90, output: 'color8' },
      { input: 100, output: 'color9' },
    ];
    data.forEach((item) => {
      expect(MapDataService.getColor(item.input)).toEqual(item.output);
    });
  });
});

describe('convertContryCode', () => {
  test('it should map from 2 letter code to 3 letter code', () => {
    const data = [
      { input: 'us', output: 'USA' },
      { input: 'cn', output: 'CHN' },
      { input: 'ru', output: 'RUS' },
      { input: 'nl', output: 'NLD' },
    ];
    data.forEach((item) => {
      expect(MapDataService.convertContryCode(item.input)).toEqual(item.output);
    });
  });
});

describe('toBubbleData', () => {
  test('it should map from RSVPCity to Bubbbe data', () => {
    const rsvpCity = new RSVPCity('nl', 'amsterdam', 10, 123.12, -124.12);

    const bubbleData = {
      name: 'amsterdam',
      country: 'NLD',
      count: 10,
      radius: 5,
      fillKey: 'color0',
      latitude: 123.12,
      longitude: -124.12,
    };

    expect(MapDataService.toBubbleData(rsvpCity)).toMatchObject(bubbleData);
  });
});

describe('toMapData', () => {
  test('it should map from RSVPCity to mapdata', () => {
    const rsvpCities: RSVPCity[] = [
      new RSVPCity('nl', 'amsterdam', 10, 123.12, -124.12),
      new RSVPCity('nl', 'amsterdam', 10, 123.12, -124.12),
    ];

    const mapdata = {
      NLD: {
        fillKey: 'color1',
        count: 20,
        topics: [],
      },
    };

    expect(MapDataService.toMapData(rsvpCities)).toMatchObject(mapdata);
  });
});

// @ts-ignore
import Datamap from 'datamaps/dist/datamaps.world.hires.min.js';
import { MapData } from '../types';

function cleanMap(): void {
  if (document.getElementsByTagName('svg') !== undefined && document.getElementsByTagName('svg').length > 0) {
    document.getElementsByTagName('svg')[0].remove();
  }
}

function drawMap(countryData: MapData, bubbleData: any): void {
  // clean up if already rendered
  cleanMap();

  const myMap = new Datamap({
    element: document.getElementById('basic_choropleth'),
    projection: 'mercator',
    scope: 'world',
    responsive: true,
    fills: {
      defaultFill: '#dddddd',
      color0: '#dddddd',
      color1: '#F0EEF6',
      color2: '#CADEF0',
      color3: '#ADDEA7',
      color4: '#82BADB',
      color5: '#59A1CF',
      color6: '#3787C0',
      color7: '#1B843F',
      color8: '#0B4D94',
      color9: '#08306B',
    },
    geographyConfig: {
      popupOnHover: true,
      highlightOnHover: true,
      highlightFillColor: 'red',
      popupTemplate(geography: any, data: any) {
        return (
          `<div class="hoverinfo">${geography.properties.name} - rsvp:${data.count}`
        );
      },
    },
    data: countryData || {
      USA: {
        fillKey: 'color0',
        count: 1900,
      },
      CHN: {
        fillKey: 'color0',
        count: 1700,
      },
      JPN: {
        fillKey: 'color0',
        count: 1930,
      },
      AUS: {
        fillKey: 'color0',
        count: 1350,
      },
      IND: {
        fillKey: 'color0',
        count: 1500,
      },
    },
  });

  // Manage responsiveness
  window.addEventListener('resize', () => {
    myMap.resize();
  });
  // configure bubbles
  myMap.bubbles(bubbleData || [],
    {
      popupTemplate(geo: any, data: any) {
        return (
          `<div class="hoverinfo">${data.name}<br /> rsvp:${data.count}`
        );
      },
    });
}

const MapService = {
  cleanMap,
  drawMap,
};

export default MapService;

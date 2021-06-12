/* eslint-disable @typescript-eslint/no-explicit-any */
// @ts-ignore
import Datamap from 'datamaps/dist/datamaps.world.hires.min.js';
import { MapData } from '../types';

// remove svg map
function cleanMap(): void {
  if (document.getElementsByTagName('svg') !== undefined && document.getElementsByTagName('svg').length > 0) {
    document.getElementsByTagName('svg')[0].remove();
  }
}

// eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types
function drawMap(id: string, countryData: MapData, bubbleData: any, displayTrendingTopics: any): void {
  // clean up if already rendered
  cleanMap();

  const myMap = new Datamap({
    element: document.getElementById(id),
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
    data: countryData,
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
  bindClickEvent(displayTrendingTopics);
}

// add map click event
function bindClickEvent(displayTrendingTopics: any) {
  const nodes = document.getElementsByClassName('datamaps-subunit');
  for (let i = 0; i < nodes.length; i += 1) {
    const node = nodes[i];
    node.addEventListener('click', () => displayTrendingTopics(node.classList[1]));
  }
}

// export service
const MapService = {
  cleanMap,
  drawMap,
};

export default MapService;

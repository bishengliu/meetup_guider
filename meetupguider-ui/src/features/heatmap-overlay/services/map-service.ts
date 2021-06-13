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
      color0: '#CE9FCD',
      color1: '#CE93C7',
      color2: '#DC64AE',
      color3: '#E33D94',
      color4: '#D81D6E',
      color5: '#C00F55',
      color6: '#BA0C51',
      color7: '#9C0442',
      color8: '#690172',
      color9: '#4E006B',
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
    node.addEventListener('click', () => { console.log(node.classList[1]); displayTrendingTopics(node.classList[1]); });
  }
}

// export service
const MapService = {
  cleanMap,
  drawMap,
};

export default MapService;

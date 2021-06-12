import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import './heatmap-overlay.css';
// @ts-ignore
import Datamap from 'datamaps/dist/datamaps.world.hires.min.js';
import AppState from '../../redux/app-state';
import HeatmapService from './services/heatmap-service';
import { getRSVPCitiesActionCreatorAsync, getCountryTopicsActionCreatorAsync } from './redux/actions/action-creators';

const HeatmapOverlay = (): JSX.Element => {
  const [isLoaded, setIsLoaded] = useState(false);
  const dispatch = useDispatch();
  const heatmapState = useSelector((state: AppState) => state.heatmapState);

  const loadRSVPCities = () => {
    dispatch(getRSVPCitiesActionCreatorAsync());
    console.log(HeatmapService.getMapData(heatmapState.rsvpCities));
    console.log(HeatmapService.getBubbleData(heatmapState.rsvpCities));
    setIsLoaded(true);
  };

  // const loadCountryTopics = () => dispatch(getCountryTopicsActionCreatorAsync('nl'));
  if (!isLoaded) {
    loadRSVPCities();
  }

  useEffect(() => {
    loadRSVPCities();

    const myMap = new Datamap({
      element: document.getElementById('basic_choropleth'),
      projection: 'mercator',
      scope: 'world',
      responsive: true,
      fills: {
        defaultFill: '#dddddd',
      },
      geographyConfig: {
        popupOnHover: true,
        highlightOnHover: true,
        highlightFillColor: 'red',
        popupTemplate(geography: any, data: any) {
          return (
            `<div class="hoverinfo">${
              geography.properties.name
            } - Year of formation:${
              data.formationDate
            } `
          );
        },
      },
      data: {
        // Country Codes list https://countrycode.org/
        USA: {
          fillKey: 'firstWorld',
          formationDate: 1900,
        },
        CHN: {
          fillKey: 'thirdWorld',
          formationDate: 1700,
        },
        JPN: {
          fillKey: 'firstWorld',
          formationDate: 1930,
        },
        AUS: {
          fillKey: 'firstWorld',
          formationDate: 1350,
        },
        IND: {
          fillKey: 'thirdWorld',
          formationDate: 1500,
        },
      },
    });

    // Manage responsiveness
    window.addEventListener('resize', () => {
      myMap.resize();
    });

    // // configure bubbles
    // myMap.bubbles(
    //   [
    //     {
    //       name: 'Tourist Spot 1',
    //       radius: 5,
    //       centered: 'IND',
    //       tourist: 3800,
    //       fillKey: 'boringSpot',
    //     },
    //     {
    //       name: 'Tourist Spot 2',
    //       radius: 5,
    //       tourist: 1500,
    //       centered: 'USA',
    //       fillKey: 'boringSpot',
    //     },
    //     {
    //       name: 'Tourist Spot 3',
    //       radius: 5,
    //       tourist: 15000,
    //       fillKey: 'interestingSpot',
    //       latitude: 11.415,
    //       longitude: 165.1619,
    //     },
    //     {
    //       name: 'Tourist Spot 4',
    //       radius: 5,
    //       tourist: 50000,
    //       fillKey: 'interestingSpot',
    //       latitude: 73.482,
    //       longitude: 54.5854,
    //     },
    //   ],
    //   {
    //     popupTemplate(geo: any, data: any) {
    //       return (
    //         `<div class="hoverinfo">${
    //           data.name
    //         }<br /> No of Tourists:${
    //           data.tourist}`
    //       );
    //     },
    //   },
    // );

    // load legend
    myMap.legend();
  }, []);

  return (
    <div id="basic_choropleth" style={{ position: 'relative', width: 'auto%', height: '30%' }} className="heatmap_guider" />
  );
};

export default HeatmapOverlay;

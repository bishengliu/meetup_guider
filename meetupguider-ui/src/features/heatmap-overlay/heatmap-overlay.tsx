import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import {
  Table, Container, Row, Col, Alert, Spinner,
} from 'react-bootstrap';
import './heatmap-overlay.css';
// @ts-ignore
import AppState from '../../redux/app-state';
import MapDataService from './services/mapdata-service';
import MapService from './services/map-service';
import { getRSVPCitiesActionCreatorAsync, getCountryTopicsActionCreatorAsync } from './redux/actions/action-creators';

const HeatmapOverlay = (): JSX.Element => {
  const [isLoaded, setIsLoaded] = useState(false);
  const dispatch = useDispatch();
  const heatmapState = useSelector((state: AppState) => state.heatmapState);

  // dispatch rsvps
  const loadRSVPCities = () => dispatch(getRSVPCitiesActionCreatorAsync());

  if (!isLoaded) {
    loadRSVPCities();
    setIsLoaded(true);
  }

  useEffect(() => {
    // load country trending topics
    const loadCountryTopics = (country: string) => dispatch(getCountryTopicsActionCreatorAsync(country.substring(0, 2)));

    // draw geo-heatmap
    MapService.drawMap('basic_choropleth',
      MapDataService.getMapData(heatmapState.rsvpCities),
      MapDataService.getBubbleData(heatmapState.rsvpCities),
      loadCountryTopics);
  }, [dispatch, heatmapState.rsvpCities, isLoaded]);

  return (
    <div>
      <Container fluid>
        <Row>
          <Col>
            { !isLoaded && heatmapState.rsvpCities.length === 0 && (
            <div className="guider_loading"><Spinner animation="grow" variant="primary" /></div>)}
          </Col>
        </Row>
        <Row>
          <Col xs lg="2">
            { heatmapState.countryTopics.length > 0 && (
            <div>
              <Table striped bordered hover size="sm" responsive>
                <thead>
                  <tr>
                    <th>Topic</th>
                    <th>Count</th>
                    <th>City</th>
                  </tr>
                </thead>
                <tbody>
                  {
                    heatmapState.countryTopics.map((ct) => (
                      <tr>
                        <td>{ ct.topicName }</td>
                        <td>{ ct.topicCount }</td>
                        <td>{ ct.city }</td>
                      </tr>
                    ))
                  }
                </tbody>
              </Table>
            </div>
            )}
            {
              isLoaded && heatmapState.countryTopics.length === 0 && (
                <Alert variant="info">click a country to load the trending topics.</Alert>
              )
            }
          </Col>
          <Col md="auto">
            <div id="basic_choropleth" className="heatmap_guider" />
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default HeatmapOverlay;

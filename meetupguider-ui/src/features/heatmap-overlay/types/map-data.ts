export interface MapData {
    [key: string] : MapDataCountry
}

export interface MapDataCountry {
    fillKey: string,
    count: number,
    topics: [],
}

export interface CountryCode {
    [key: string]: string,
}

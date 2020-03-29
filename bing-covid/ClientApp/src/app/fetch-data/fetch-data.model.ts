  export interface Area3 {
    id: string;
    displayName: string;
    areas: any[];
    totalConfirmed: number;
    totalDeaths?: number;
    totalRecovered?: number;
    lastUpdated: Date;
    lat: number;
    long: number;
    parentId: string;
  }

  export interface Area2 {
    id: string;
    displayName: string;
    areas: Area3[];
    totalConfirmed: number;
    totalDeaths?: number;
    totalRecovered?: number;
    lastUpdated: Date;
    lat: number;
    long: number;
    parentId: string;
  }

  export interface Area1 {
    id: string;
    displayName: string;
    areas: Area2[];
    totalConfirmed: number;
    totalDeaths?: number;
    totalRecovered?: number;
    lastUpdated: Date;
    lat: number;
    long: number;
    parentId: string;
  }

  export interface GlobalInfo {
    id: string;
    displayName: string;
    areas: Area1[];
    totalConfirmed: number;
    totalDeaths: number;
    totalRecovered: number;
    lastUpdated: Date;
  }




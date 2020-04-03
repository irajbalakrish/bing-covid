  export interface GlobalInfo {
    countryCode: string;
    country: string;
    lat?: number;
    lng?: number;
    totalConfirmed: number;
    totalDeaths: number;
    totalRecovered: number;
    dailyConfirmed: number;
    dailyDeaths: number;
    activeCases: number;
    totalCritical: number;
    totalConfirmedPerMillionPopulation: number;
    totalDeathsPerMillionPopulation?: number;
    FR: string;
    PR: string;
    lastUpdated: Date;
  }




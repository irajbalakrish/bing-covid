import {AfterViewInit, Component, Inject, ViewChild} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Area1, GlobalInfo} from './fetch-data.model';
import {MatTableDataSource} from '@angular/material/table';
import {MatSort} from '@angular/material/sort';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data-style.css']
})
export class FetchDataComponent implements AfterViewInit {
  public forecasts: GlobalInfo;
  public dataSource = new MatTableDataSource<Area1>();
  displayedColumns: string[] = ['id', 'totalConfirmed', 'totalRecovered', 'totalDeaths'];
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
  }

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<GlobalInfo>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
      this.dataSource.data = this.forecasts.areas;
    }, error => console.error(error));
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}


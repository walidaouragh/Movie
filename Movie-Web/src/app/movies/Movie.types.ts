declare module namespace {

  export interface IStudio {
    studioId: number;
    name: string;
    city: string;
    state: string;
  }

  export interface IRating {
    ratingId: number;
    stars: number;
    movieId: number;
  }

  export interface IMovie {
    movieId?: number;
    name: string;
    category: string;
    description: string;
    price: number;
    studio?: IStudio;
    ratings?: Array<IRating>;
  }

}



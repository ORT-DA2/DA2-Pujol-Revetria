import {Review} from './review.model';

export class Accommodation{
  public id : number;
  public name : string;
  public contactNumber : string;
  public address : string;
  public information : string;
  public price : number;
  public score : number;
  public images : string[];
  public reviews : Review[];
}

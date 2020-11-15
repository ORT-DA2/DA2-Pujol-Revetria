import {Guest} from './guest.model'

export class Booking{
  public id : number;
  public accommodationId : number;
  public checkIn : string;
  public CheckOut : string;
  public GuestEmail : string;
  public GuestName : string;
  public GuestLastName : string;
  public Guests : Guest[];
}

#pragma once

using namespace System;

namespace FlacSquisher {

	public ref class OptionsSet {
	public:	OptionsSet(){

			}
	private:
		int encoder;
		int target;
		bool mono;
		bool cbr;
		int bitrate;
		int quality;
		int vbrmode;

	public: void setEncoder(int en){
				encoder = en;
			}
	public: int getEncoder(){
				return encoder;
			}
	public: void setTarget(int tar){
				target = tar;
			}
	public: int getTarget(){
				return target;
			}
	public: void setMono(bool mon){
				mono = mon;
			}
	public: bool getMono(){
				return mono;
			}
	public: void setCbr(bool cb){
				cbr = cb;
			}
	public: bool getCbr(){
				return cbr;
			}
	public: void setBitrate(int bitr){
				bitrate = bitr;
			}
	public: int getBitrate(){
				return bitrate;
			}
	public: void setQuality(int qual){
				quality = qual;
			}
	public: int getQuality(){
				return quality;
			}
	public: void setVbrmode(int mode){
				vbrmode = mode;
			}
	public: int getVbrmode(){
				return vbrmode;
			}
	};
}